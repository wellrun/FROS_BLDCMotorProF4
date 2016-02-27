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
       启动文件已经被修改过了,如果FreeRTOSConfig.h最后有三个定义如下
           #define vPortSVCHandler SVC_Handler
           #define xPortPendSVHandler PendSV_Handler
           #define xPortSysTickHandler SysTick_Handler
       则不用修改启动文件.
       system_stm32f4xx.c默认外部晶振25M需改成8M,不然后RCC就会出问题
 ********************************************************************************/
/*#includes**********************************************************************/
#include "bsp_init.h"
#include "app.h"

/*#define************************************************************************/
#define  MyDelay(n)  while(n--)
#define  OS_Debug

#ifndef  OS_Debug  //实际用

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
float temp_speed = 0;
int main(void)
{
    u32 ii = 0;
    u8 n = 0;
    StateLED_Init();
    Bsp_NVIC_Config();
    TIM1_PWM_Config();
    
    RCC_ClocksTypeDef mysystemclock;
    RCC_GetClocksFreq(&mysystemclock);
    Set_MotorSpeed(-300);
    Hall_PrepareCommutation();/*预换相,启动时需要*/
    Manual_COMevent();
//    temp_speed = 300;
    while (1)   //可以在这里对某些功能进行单独的测试
    {
        Set_MotorSpeed(temp_speed);
        ii = 0x01f0000f;
        MyDelay(ii);
        TurnStateLED(n);
        n = !n;
//        if(n)
//        {
//            temp_speed = 300;
//        }
//        else
//        {
//            temp_speed = -300;            
//        }
    }
}
#endif

/****************** end of this file ********************************************


                                                             Copyright @JohnBee */
