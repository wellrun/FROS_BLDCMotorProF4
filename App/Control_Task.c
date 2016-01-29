/********************************************************************************
  * @FileName   Control_Task.c
  * @Author     Johnbee
  * @Version    V1.0.0
  * @Date       2015/11/23
  * @Brief      电机控制任务
                Iface_前缀的变量均为对外接口
  *******************************************************************************/
/*#includes**********************************************************************/
#include "Control_Task.h"
#include "sal_PID.h"
#include "sal_KalmanFilter.h"

/*#define************************************************************************/
#define   CONTROL_TASK_STK_SIZE		   512 //设置栈大小

/*全局变量声明*******************************************************************/
PIDTypeDef         PID_Loction,PID_Speed,PID_Current;  //位置,速度,电流环
MotorParamStruct   Iface_MyMotor;
KFParamStruct      KF_Speed;

/*
 *@<function name=> Control_Task_Create() </function>
 *@<summary>
    创建控制任务
 *@</summary>
 *@<param name="myPrio"> 任务优先级</param>
 *@<returns> null </returns>
*/
void Control_Task_Create(u8 myPrio)
{
    xTaskCreate(Control_Task,
                "control_task",
                CONTROL_TASK_STK_SIZE,
                ( void * ) NULL,
                myPrio,NULL); 
}
/*
 *@<function name=> Control_Task() </function>
 *@<summary>
    控制任务
 *@</summary>
 *@<param name="pdata">no use</param>
 *@<returns> null </returns>
*/
static void Control_Task(void *pdata)
{
    float now_speed = 0,now_lenth = 0;//速度位移的反馈值
    static u8 ii = 0,jj  = 0;
    (void)pdata;                		// 'pdata' 并没有用到，防止编译器提示警告
    
    Set_PID_Param(&PID_Loction,0,1,0,0,250,-250);//初始化变量
    Set_PID_Param(&PID_Speed,1,0.5,0,0,800,-800);
    Set_PID_Param(&PID_Current,0,1,0,0,10000,-10000);
    KF_Simple_Init(&KF_Speed,0,10,100,100);
    while(1)
    {
        vTaskDelay(1*configTICK_RATE_HZ/1000);  //延时函数        
        if(jj == 0)//外环
        {
            jj = 10;
            now_lenth = Get_Encoder_Lenth();
            PID_Cal(&PID_Loction,Iface_MyMotor.lenth,now_lenth,100);//PID计算
            Iface_MyMotor.speed = PID_Loction.ref;
        }

        if(ii == 0)//内环
        {
            ii = 3;
            now_speed = Get_Encoder_Speed();
         //   now_speed = KF_Simple_Calculate(&KF_Speed,now_speed);//速度KF滤波     

            PID_Cal(&PID_Speed,Iface_MyMotor.speed,now_speed,10);//PID计算
            PID_Speed.ref += PID_Speed.fd * Iface_MyMotor.speed; //加前馈
    //        PID_Speed.ref = Iface_MyMotor.speed;//开环测试
            
            Set_MotorSpeed(PID_Speed.ref);
            Send_Data(now_lenth,ID_Osc_CH2);           
            Send_Data(now_speed,ID_Osc_CH3);                      
        }
        ii--,jj--;
    }
}

/****************** end of this file ********************************************


                                                             Copyright @JohnBee */
