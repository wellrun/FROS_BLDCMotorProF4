/*********************************************************************************
 *@FileName   bsp_ADC.h
 *@Version    V0.0.0.1
 *@Author     Johnbee
 *@Date       2015/11/16
 *@Brief      ADC≈‰÷√
 *********************************************************************************/
#ifndef   _BSP_ADC_H_
#define   _BSP_ADC_H_

/*#include************************************************************************/
#include "bsp_Init.h"

#define  ADC_Converted_Num1    (30u)
#define  ADC_Converted_Num2    (10u)

extern uint16_t  ADC_USED_ConvertedValue1[ADC_Converted_Num1];//ª∫≥Â«¯1
extern uint16_t  ADC_USED_ConvertedValue2[ADC_Converted_Num2];//ª∫≥Â«¯2
extern float Current_Value;

void Bsp_ADC_Init(void);
void DMA_Phase_ADC_NVIC(u8 prePriority,u8 subPriority);
void DMA_Current_ADC_NVIC(u8 prePriority,u8 subPriority);

void Get_Current_ADC_Value(void);

static void ADC_Start(void);
static void Phase_ADC_GPIO_Config(void);
static void Phase_ADC_Config(void);
static void Phase_ADC_DMA_Config(void);
static void Current_ADC_GPIO_Config(void);
static void Current_ADC_Config(void);
static void Current_ADC_DMA_Config(void);

#endif
/**************************End of this file***************************************
 


                                          Copyright @JohnBee */
