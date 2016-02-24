/********************************************************************************
 *@FileName    bsp_Commutation.c
 *@Author      Johnbee
 *@Version     V0.1
 *@Date        2015/02/23
 *@Brief       电机换相
 *******************************************************************************/
/*#includes*********************************************************************/
#include "bsp_Commutation.h"

/*#define***********************************************************************/
#define  MyAbs(a)    (a>0?a:-a)
    
/*全局变量声明******************************************************************/
static u8 State_TabIndex = 0; //换相时电流状态表的下标
static float Motor_SetedSpeed = 0;  //电机速度-100~100
static s16 Middle_PWM_Duty = 50;

static const  s8 I_IN  = 1;  //电流流入,相电流为正
static const  s8 I_OUT = -1; //电流流出,相电流为负
static const  s8 I_OFF = 0;  //无电流
/*换相时A,B,C相电流状态状态表,120度霍尔*/
/*1.B+A-    5.B+C-   4.A+C-     6.A+B-   2.C+B-    3.C+A-*///正向
/*3.A+B-    2.A+C-   6.B+C-     4.B+A-   5.C+A-    1.C+B-*///反向

static const s8 BLDC_STATE_TAB[8][3] =  //正向表
{
    {I_OFF, I_OFF, I_OFF},  //CBA = 000时ABC三相电流方向
    {I_OUT, I_IN , I_OFF},  //B+A-;
    {I_OFF, I_OUT, I_IN },  //C+B-;
    {I_OUT, I_OFF, I_IN },  //C+A-;
    {I_IN , I_OFF, I_OUT},  //A+C-;
    {I_OFF, I_IN , I_OUT},  //B+C-;
    {I_IN,  I_OUT, I_OFF},  //A+B-;
    {I_OFF, I_OFF, I_OFF},  //CBA = 111,120度霍尔不会出现这种情况,如果出现了一定有问题,所以马上刹车
};
static const s8 BLDC_STATE_TAB_Fan[8][3] =  //反向表
{
    {I_OFF, I_OFF, I_OFF},  //CBA = 000时ABC三相电流方向
    {I_OFF, I_OUT, I_IN },  //C+B-;
    {I_IN , I_OFF, I_OUT},  //A+C-;
    {I_IN,  I_OUT, I_OFF},  //A+B-;    
    {I_OUT, I_IN , I_OFF},  //B+A-;    
    {I_OUT, I_OFF, I_IN },  //C+A-;    
    {I_OFF, I_IN , I_OUT},  //B+C-;
    {I_OFF, I_OFF, I_OFF},  //CBA = 111,120度霍尔不会出现这种情况,如果出现了一定有问题,所以马上刹车
};

/*
 *@ <function name=>Hall_PrepareCommutation() </function>
 *@ <summary>
     霍尔产生的换相事件
 *@ </summary>
 *@ <param name="void">null</param>
 *@ <returns> null </returns>
 */
void Hall_PrepareCommutation(void)
{
    static u16 lasthallpos = 0;
//    float temp_duty = 0;  //临时占空比
    s8 hall_state[3] = {0, 0, 0}; //ABC三相状态数组
    u16 newhallpos = 0;
//    GPIO_ReadInputDataBit(HallA_Port, HallA_Pin)
//                     + GPIO_ReadInputDataBit(HallB_Port, HallB_Pin) * 2
//                     + GPIO_ReadInputDataBit(HallC_Port, HallC_Pin) * 4;
    State_TabIndex = newhallpos;

    if (newhallpos == lasthallpos)
    {
        return;  //无换相事件
    }
//    if(Motor_SetedSpeed == 0)
//    {
//        TIM1_Set_PWMOutput_EnableState(1, 0, 0); //全桥拉低
//        TIM1_Set_PWMOutput_EnableState(2, 0, 0); //全桥拉低
//        TIM1_Set_PWMOutput_EnableState(3, 0, 0); //全桥拉低
//        return;  //       
//    }
#if 1   //拉低一桥的换相
    for (u8 ii = 0; ii < 3; ii++) /*先找到off的桥先拉低*/
    {
        #if 1 //双表换相
        if(Motor_SetedSpeed>0)
        {
           hall_state[ii] = BLDC_STATE_TAB[newhallpos][ii];//正向         
        }
        else
        {
           hall_state[ii] = BLDC_STATE_TAB_Fan[newhallpos][ii]; //反向                    
        }
        #endif
        #if 0 //单表换相
           hall_state[ii] = BLDC_STATE_TAB[newhallpos][ii];//正向        
        #endif
        if (hall_state[ii] == 0)
        {
            TIM1_Set_PWMOutput_EnableState(ii + 1, 0, 0); //全桥拉低
            //break;
        }
    }
    for (u8 ii = 0; ii < 3; ii++) /**/
    {
        #if 1 //双表换相
        if(Motor_SetedSpeed>=0)
        {
           hall_state[ii] = BLDC_STATE_TAB[newhallpos][ii];//正向         
        }
        else
        {
           hall_state[ii] = BLDC_STATE_TAB_Fan[newhallpos][ii]; //反向                    
        }
        #endif
        #if 0 //单表换相
           hall_state[ii] = BLDC_STATE_TAB[newhallpos][ii];//正向        
        #endif
        if (hall_state[ii] != 0)
        {
            TIM1_Set_PWMOutput_EnableState(ii + 1, 1, 1); // 使能输出
        }
    }
#endif
    lasthallpos = newhallpos;
}
/*
 *@ <function name=>Set_MotorSpeed() </function>
 *@ <summary>
    设置电机速度
 *@ </summary>
 *@ <param name="speed">速度从-1000到1000</param>
 *@ <returns> null </returns>
 */
void Set_MotorSpeed(float speed)
{
#if 1  //只负责改变占空比,使能在换相事件中改变,双表换相
    s8 hall_state[3] = {0, 0, 0}; //ABC三相状态数组
    float temp_duty = 0;  //临时占空比
    static float last_speed = 0;
    Motor_SetedSpeed = speed / 10.0;
    if(last_speed*Motor_SetedSpeed<=0)
    { 
        /*上次和这次速度方向不同时要触发一次换相事件*/
        Hall_PrepareCommutation();
    }
    for(u8 ii = 0; ii<3;ii++)
    {  
        #if 1 //双表换相
        if(Motor_SetedSpeed>=0)
        {
           hall_state[ii] = BLDC_STATE_TAB[State_TabIndex][ii];//正向         
        }
        else
        {
           hall_state[ii] = BLDC_STATE_TAB_Fan[State_TabIndex][ii]; //反向                    
        }
//        temp_duty = hall_state[ii] * MyAbs(Motor_SetedSpeed)/ 2.0;
        temp_duty = hall_state[ii] * Motor_SetedSpeed/ 2.0;      

        #endif
        #if 0 //单表换相
        hall_state[ii] = BLDC_STATE_TAB[State_TabIndex][ii];//正向  
        temp_duty = hall_state[ii] * Motor_SetedSpeed/ 2.0;      
        #endif
        temp_duty += Middle_PWM_Duty;
        TIM1_Set_PWMDuty(ii + 1, temp_duty); 
    } 
    last_speed = Motor_SetedSpeed;
#endif
}
/*
 *@ <function name=>GraytoDecimal() </function>
 *@ <summary>
    u16类型的Gray码转十进制
 *@ </summary>
 *@ <param name="x">Gray码</param>
 *@ <returns> Gray码对应的十进制数 </returns>
 */
static u16 GraytoDecimal(u16 x) 
{ 
    u16 y = x; 
    while(x>>=1) 
    {
        y ^= x;        
    }
    return y;        
}
/****************** end of this file ********************************************


                                                             Copyright @JohnBee */

