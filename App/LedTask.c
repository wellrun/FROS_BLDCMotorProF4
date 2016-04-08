/********************************************************************************
  * @FileName   LedTask.c
  * @Author     Johnbee
  * @Version    V1.0.0
  * @Date       2016/04/01
  * @Brief      Led任务
  *******************************************************************************/
/*#includes**********************************************************************/
#include "LedTask.h"
/*#define************************************************************************/
#define  LED_TASK_STK_SIZE		   128u //设置栈大小


/*
 *@<function name=> LED_Task_Create() </function>
 *@<summary>
    创建任务
 *@</summary>
 *@<param name="myPrio">任务优先级</param>
 *@<returns> null </returns>
*/
void LED_Task_Create(u8 myPrio)
{
    xTaskCreate(LED_Task,
                "main_task",
                LED_TASK_STK_SIZE,
                ( void * ) NULL,
                myPrio, NULL);
}
/*
 *@<function name=> LED_Task() </function>
 *@<summary
    led任务
 *@</summary>
 *@<param name="pdata">null</param>
 *@<returns> null </returns>
*/
static void LED_Task(void *pdata)
{
    (void)pdata;   // 'pdata' 并没有用到，防止编译器提示警告
    u8 bled_flag = Led_ON;
    while (1)
    {
        vTaskDelay(configTICK_RATE_HZ); //延时函数
        Set_LED(BlueLed,bled_flag);
        bled_flag = ~bled_flag;   
    }
}
/****************** end of this file ********************************************


                                                             Copyright @JohnBee */
