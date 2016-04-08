/********************************************************************************
  * @FileName   MainTask.c
  * @Author     Johnbee
  * @Version    V1.0.0
  * @Date       2015/10/02
  * @Brief      主任务,一般用于逻辑交互处理
  *******************************************************************************/
/*#includes**********************************************************************/
#include "MainTask.h"

/*#define************************************************************************/
#define  MAIN_TASK_STK_SIZE		   512u //设置栈大小

/*
 *@<function name=> Main_Task_Create() </function>
 *@<summary>
    创建任务
 *@</summary>
 *@<param name="myPrio">任务优先级</param>
 *@<returns> null </returns>
*/
void Main_Task_Create(u8 myPrio)
{
    xTaskCreate(Main_Task,
                "main_task",
                MAIN_TASK_STK_SIZE,
                ( void * ) NULL,
                myPrio,NULL);
}
/*
 *@<function name=> Main_Task() </function>
 *@<summary>
    主任务
 *@</summary>
 *@<param name="pdata">null</param>
 *@<returns> null </returns>
*/
static void Main_Task(void *pdata)
{
    (void)pdata;   // 'pdata' 并没有用到，防止编译器提示警告
    while(1)
    {
        vTaskDelay(5*configTICK_RATE_HZ/1000);  //延时函数
        Iface_MyMotor.speed = ComData[ID_Loc_Ki3];//速度闭环
        Iface_MyMotor.lenth = 5*ComData[ID_Loc_Kp3];//位移闭环

        PID_Loction.kp = ComData[ID_Loc_Kp1]/10;
        PID_Loction.ki = ComData[ID_Loc_Ki1]/10;
        PID_Loction.kd = ComData[ID_Loc_Kd1]/10;
        
        PID_Speed.kp = ComData[ID_Psi_Kp1]/10;
        PID_Speed.ki = ComData[ID_Psi_Ki1]/10;
        PID_Speed.kd = ComData[ID_Psi_Kd1]/10;
        if(Iface_MyMotor.speed != 0)
        {
            Set_MotorState(1);
        }
        else
        {
            Set_MotorState(0);            
        }
        Send_Data(Current_Value,ID_Osc_CH1);      
    }
}

/****************** end of this file ********************************************


                                                             Copyright @JohnBee */
