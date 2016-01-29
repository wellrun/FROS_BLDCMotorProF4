/********************************************************************************
  * @FileName   main.c
  * @Author     Johnbee
  * @Version    V1.0.0
  * @Date       2015/10/02
  * @Brief      基于FreeRTOS操作系统的STM32F4xx工程
  *******************************************************************************/
/*********************************************************************************
   关于程序的预编译选项在Johnbee_dbg.h文件里
   用static 修饰的函数仅供内部调用
   每个单词首字母都大写的变量为全局变量,如MyValue
   首字母小写剩于单词首字母大写的变量为形参,如myValue
   全小写的变量为局部变量,如temp_value
*注    意:
       启动文件已经被修改过了
       system_stm32f4xx.c默认外部晶振25M需改成8M,不然后RCC就会出问题
 ********************************************************************************/
/*#includes**********************************************************************/
#include "bsp_init.h"
#include "app.h"

/*#define************************************************************************/
#define Delay(n)  while(n--)
//#define OS_Debug

#ifndef OS_Debug  //实际用

/*********************************************************************************
 * @函数名称  main()
 * @函数功能  主函数
 * @入口参数  无
 * @出口参数  无
*********************************************************************************/
int main(void)
{
    xQueueHandle queue = xQueueCreate(1, sizeof( unsigned long ));

    if(queue != NULL)
    {
        Bsp_Init();  //各种初始化

        Start_Task_Create();  //创建开始任务       
        vTaskStartScheduler();   //启动调度器，开始执行任务
    }
    while(1);
}

#endif
#ifdef OS_Debug   //测试用
/*********************************************************************************
 * @函数名称  main()
 * @函数功能  主函数
 * @入口参数  无
 * @出口参数  无
*********************************************************************************/
int main(void)
{
    float recieve_speed = 0;
    static s16 delta_encoder = 0;
    static s16 adc_value = 0;
    u16 ii = 0x0fff;
    Bsp_Init();  //各种初始化
    while (1)   //可以在这里对某些功能进行单独的测试
    {
        ii--;
        recieve_speed = ComData[ID_Loc_Kp3];
        #if 0  //测试是否失能时有重叠
        TIM1_Set_PWMDuty(3, recieve_speed);
        TIM1_Set_PWMOutput_EnableState(3, 1, 1); // 使能输出
        TIM1_Set_PWMOutput_EnableState(3, 0, 0); // 使能输出
        #endif
        #if 1 //开环控制
        Set_MotorSpeed(recieve_speed);
        #endif
        if(ii == 0)
        {
            #if 1 // 测试串口
            adc_value = Get_ADC_Value();
            delta_encoder = Get_Encoder_Value();
            Send_Data(-delta_encoder/10.0,ID_Osc_CH2);
            Send_Data(-adc_value/100,ID_Osc_CH3);           
            #endif
            ii = 0x0fff;
        }
    }
}
#endif

/****************** end of this file ********************************************


                                                             Copyright @JohnBee */
