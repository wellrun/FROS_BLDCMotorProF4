/********************************************************************************
 *@FileName    bsp_TIM.h
 *@Author      Johnbee
 *@Version     V0.1
 *@Date        2015/10/19
 *@Brief       ≈‰÷√PWM ‰≥ˆ
 *******************************************************************************/
#ifndef _BSP_PWM_H_
#define _BSP_PWM_H_

/*#includes*********************************************************************/
#include "bsp_init.h"


void TIM1_PWM_Config(void);
void TIM1_TRG_COM_NVIC_Config(u8 preemPriority, u8 subPriority);

void TIM1_Set_PWMDuty(u8 myChannel, float myDuty);
void TIM1_Set_PWMOutput_EnableState(u8 myChannel, u8 pState,u8 nState);
void Manual_COMevent(void);

static void TIM1_GPIO_Config(void);

#endif
/****************** end of this file ********************************************


                                                             Copyright @JohnBee */

