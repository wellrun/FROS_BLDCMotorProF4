/********************************************************************************
  * @FileName   EncoderTask.c
  * @Author     Johnbee
  * @Version    V1.0.0
  * @Date       2015/12/14
  * @Brief      编码器任务
  *******************************************************************************/
/*#includes**********************************************************************/
#include "EncoderTask.h"

/*#define************************************************************************/
#define Encoder_TASK_STK_SIZE		   128u //设置栈大小
#define   Encoder_Resolution          (400u) //编码器分辨率

/*全局变量声明*******************************************************************/
float Encoder_Lenth = 0,Encoder_Speed = 0;

/*
 *@<function name=> Encoder_Task_Create() </function>
 *@<summary>
    创建任务
 *@</summary>
 *@<param name="myPrio">任务优先级</param>
 *@<returns> null </returns>
*/
void Encoder_Task_Create(u8 myPrio)
{
    xTaskCreate(Encoder_Task,
                "encoder_task",
                Encoder_TASK_STK_SIZE,
                ( void * ) NULL,
                myPrio,NULL);
}
/*
 *@<function name=> Encoder_Task() </function>
 *@<summary>
    主任务
 *@</summary>
 *@<param name="pdata">null</param>
 *@<returns> null </returns>
*/
void Encoder_Task(void *pdata)
{
    s16 temp = 0;

    (void)pdata;                		// 'pdata' 并没有用到，防止编译器提示警告

    while(1)
    {
        vTaskDelay(5*configTICK_RATE_HZ/1000);  //延时函数
        temp = Get_Encoder_Value();
        Encoder_Lenth += temp;
        Encoder_Speed = 3000.0*temp/Encoder_Resolution;//测速r/min
    }
}
/*
 *@<function name=> Get_Encoder_Speed() </function>
 *@<summary>
    获取编码器速度
 *@</summary>
 *@<param name="void">null</param>
 *@<returns> speed </returns>
*/
float Get_Encoder_Speed(void)
{
    return Encoder_Speed;
}
/*
 *@<function name=> Get_Encoder_Lenth() </function>
 *@<summary>
    获取编码器位移
 *@</summary>
 *@<param name="void">null</param>
 *@<returns> speed </returns>
*/
float Get_Encoder_Lenth(void)
{
    return Encoder_Lenth;
}
/*
 *@<function name=> Set_Encoder_Lenth() </function>
 *@<summary>
    设置编码器位移,可用于清零操作
 *@</summary>
 *@<param name="void">null</param>
 *@<returns> speed </returns>
*/
void Set_Encoder_Lenth(float myLenth)
{
    Encoder_Lenth = myLenth;
}
/****************** end of this file ********************************************


                                                             Copyright @JohnBee */
