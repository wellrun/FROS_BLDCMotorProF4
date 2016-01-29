/********************************************************************************
 *@FileName    MainTask.h
 *@Author      Johnbee
 *@Version     V0.1
 *@Date        2015/10/02
 *@Brief       主任务,一般用于逻辑交互处理
 *******************************************************************************/
#ifndef     _MAIN_TASK_H_
#define     _MAIN_TASK_H_

/*#includes*********************************************************************/
#include "app.h"

void Main_Task_Create(u8 myPrio);
static void Main_Task(void *pdata);

#endif
/****************** end of this file ********************************************


                                                             Copyright @JohnBee */
