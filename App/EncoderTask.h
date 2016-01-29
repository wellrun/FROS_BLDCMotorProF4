/********************************************************************************
 *@FileName    EncoderTask.h
 *@Author      Johnbee
 *@Version     V0.1
 *@Date        2015/12/14
 *@Brief       ±àÂëÆ÷ÈÎÎñ
 *******************************************************************************/
#ifndef     _ENCODER_TASK_H_
#define     _ENCODER_TASK_H_

/*#includes*********************************************************************/
#include "app.h"

void Encoder_Task_Create(u8 myPrio);
void Encoder_Task(void *pdata);
float Get_Encoder_Lenth(void);
float Get_Encoder_Speed(void);
void Set_Encoder_Lenth(float myLenth);

#endif
/****************** end of this file ********************************************


                                                             Copyright @JohnBee */
