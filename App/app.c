/********************************************************************************
  * @FileName   app.c
  * @Author     Johnbee
  * @Version    V1.0.0
  * @Date       2015/10/02
  * @Brief      起始任务,一般来说只运行一次
  *******************************************************************************/
/*#includes**********************************************************************/
#include "app.h"

/*#define************************************************************************/
#define STARTUP_TASK_PRIO		  10u //设置任务优先级
#define MAIN_TASK_PRIO		      4u 
#define CONTROL_TASK_PRIO         2u 
#define USART_TASK_PRIO           9u
#define Encoder_TASK_PRIO         1u
#define LED_TASK_PRIO             8u

/*
 *@<function name=> Start_Task_Create() </function>
 *@<summary>
    创建开始任务
 *@</summary>
 *@<param name="void"> no use</param>
 *@<returns> null </returns>
*/
void Start_Task_Create(void)
{
    xTaskCreate(Start_Task,          //创建起始任务
                "OSStatInit",
                128,
                (void *)NULL,
                STARTUP_TASK_PRIO,
                NULL);
}
/*********************************************************************************
 * @函数名称  Start_Task()
 * @函数功能  开始任务
 * @入口参数  pdata
 * @出口参数  无
*********************************************************************************/
static void Start_Task(void *pvParameters)
{
    (void)pvParameters; 
    vTaskDelay(60*configTICK_RATE_HZ);  //延时60s等待电流稳定后再采样        

    Bsp_Init();  //各种初始化      
    taskENTER_CRITICAL();             //关中断    
    /*在这里创建其他任务*/
    Main_Task_Create(MAIN_TASK_PRIO);
    Control_Task_Create(CONTROL_TASK_PRIO);
    USART_Task_Create(USART_TASK_PRIO);
    Encoder_Task_Create(Encoder_TASK_PRIO);  
    LED_Task_Create(LED_TASK_PRIO);    
    taskEXIT_CRITICAL();         //开中断
    vTaskDelete(NULL);   //删除自己
}
/****************** end of this file ********************************************


                                                             Copyright @JohnBee */
