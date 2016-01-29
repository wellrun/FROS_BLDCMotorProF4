/*********************************************************************************
 *@FileName   bsp_ADC.h
 *@Version    V0.0.0.1
 *@Author     Johnbee
 *@Date       2015/11/16
 *@Brief      ADC配置
 *********************************************************************************/
#ifndef   _BSP_ADC_H_
#define   _BSP_ADC_H_

/*#include************************************************************************/
#include "bsp_Init.h"

#define  ADC_Converted_Num    (50u)
extern uint16_t  ADC_USED_ConvertedValue1[ADC_Converted_Num];//缓冲区1
//extern uint16_t  ADC_USED_ConvertedValue2[ADC_Converted_Num];//缓冲区2
//extern u8   DMA_TC_Flag;//DMA传输完成标志

void Bsp_ADC_Init(void);
void DMA_ADC_NVIC(u8 prePriority,u8 subPriority);
s16 Get_ADC_Value(void);

static void ADC_GPIO_Config(void);
static void ADC_Config(void);
static void ADC_DMA_Config(void);
#endif
/**************************End of this file***************************************
 


                                          Copyright @JohnBee */
