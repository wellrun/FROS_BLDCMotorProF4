/*********************************************************************************
 *@FileName   bsp_ADC.c
 *@Version    V0.0.0.1
 *@Author     Johnbee
 *@Date       2015/11/16
 *@Brief      ADC配置
 *********************************************************************************/
/*#include************************************************************************/
#include "bsp_ADC.h"

/*#define*************************************************************************/
#ifdef  _STM32F10x_
    #define ADC_USED              ADC1
    #define ADC_USED_Channel      ADC_Channel_9
    #define RCC_ADC_USED          RCC_APB2Periph_ADC1
    #define ADC_USED_Port         GPIOB
    #define ADC_USED_Pin          GPIO_Pin_1
    #define RCC_ADC_USED_Port     RCC_APB2Periph_GPIOB//| RCC_APB2Periph_AFIO
    #define ADC_USED_DR           (uint32_t)(&ADC_USED->DR)
    #define ADC_DMA_Channel       DMA1_Channel1
    #define RCC_ADC_DMA           RCC_AHBPeriph_DMA1
#endif
#ifdef  _STM32F4xx_  //未修改
    #define USED_ADC                   ADC1
    #define RCC_USED_ADC               RCC_APB2Periph_ADC1
    #define USED_ADC_Port              GPIOA
    #define USED_ADC_Pin               GPIO_Pin_0|GPIO_Pin_1|GPIO_Pin_2|GPIO_Pin_3
    #define RCC_USED_ADC_Port          RCC_AHB1Periph_GPIOA
#endif
/*全局变量声明********************************************************************/
uint16_t  ADC_USED_ConvertedValue1[ADC_Converted_Num];//缓冲区1
//uint16_t  ADC_USED_ConvertedValue2[ADC_Converted_Num];//缓冲区2

__IO uint16_t ADC_ConvertedValue;

u8   DMA_TC_Flag = 0;//DMA传输完成标志
//u8   DMA_HT_Flag = 0; //DMA半传输完成标志
/*
 *@ <function name=>Bsp_ADC_Init() </function>
 *@ <summary>
    ADC配置
 *@ </summary>
 *@ <param name="xxx"></param>
 *@ <returns> </returns>
*/
void Bsp_ADC_Init(void)
{
    ADC_GPIO_Config();
    ADC_DMA_Config();
    ADC_Config(); 
}

/*
 *@ <function name=>ADC_GPIO_Config() </function>
 *@ <summary>
    ADC引脚配置
 *@ </summary>
 *@ <param name="void"></param>
 *@ <returns> </returns>
*/
static void ADC_GPIO_Config(void)
{
#ifdef _STM32F10x_
    GPIO_InitTypeDef GPIO_InitStructure;
    RCC_APB2PeriphClockCmd(RCC_ADC_USED_Port, ENABLE);

    /* Configure ADC3 Channel12 pin as analog input*/
    GPIO_InitStructure.GPIO_Pin = ADC_USED_Pin;
    GPIO_InitStructure.GPIO_Mode = GPIO_Mode_AIN;
 	GPIO_InitStructure.GPIO_Speed = GPIO_Speed_50MHz;
   
    GPIO_Init(ADC_USED_Port, &GPIO_InitStructure);
#endif
#ifdef _STM32F4xx_
    GPIO_InitTypeDef GPIO_InitStructure;
    RCC_AHB1PeriphClockCmd(RCC_USED_ADC_Port, ENABLE);

    /* Configure ADC Channel pin as analog input*/
    GPIO_InitStructure.GPIO_Pin = USED_ADC_Pin;
    GPIO_InitStructure.GPIO_Mode = GPIO_Mode_AN;
    GPIO_InitStructure.GPIO_PuPd = GPIO_PuPd_NOPULL ;
    GPIO_InitStructure.GPIO_Speed = GPIO_Speed_100MHz;    
    GPIO_Init(USED_ADC_Port, &GPIO_InitStructure);
#endif
}
/*
 *@ <function name=>ADC_Config() </function>
 *@ <summary>
    ADC配置
 *@ </summary>
 *@ <param name="void"></param>
 *@ <returns> </returns>
*/
static void ADC_Config(void)
{
#ifdef _STM32F10x_
	ADC_InitTypeDef ADC_InitStructure;
    RCC_APB2PeriphClockCmd(RCC_ADC_USED, ENABLE);

    ADC_DeInit( ADC_USED );
	/* ADC1 configuration */	
	ADC_InitStructure.ADC_Mode = ADC_Mode_Independent;			//独立ADC模式
	ADC_InitStructure.ADC_ScanConvMode = DISABLE ; 	 				//禁止扫描模式，扫描模式用于多通道采集
	ADC_InitStructure.ADC_ContinuousConvMode = ENABLE;			//开启连续转换模式，即不停地进行ADC转换
	ADC_InitStructure.ADC_ExternalTrigConv = ADC_ExternalTrigConv_None;	//不使用外部触发转换
	ADC_InitStructure.ADC_DataAlign = ADC_DataAlign_Right; 	//采集数据右对齐
	ADC_InitStructure.ADC_NbrOfChannel = 1;	 								//要转换的通道数目1
	ADC_Init(ADC_USED, &ADC_InitStructure);
	
	/*配置ADC时钟，为PCLK2的8分频，即9MHz*/
	RCC_ADCCLKConfig(RCC_PCLK2_Div8); 
	/*配置ADC1的通道11为55.	5个采样周期，序列为1 */ 
	ADC_RegularChannelConfig(ADC_USED, ADC_USED_Channel, 1, ADC_SampleTime_55Cycles5);	
	/* Enable ADC1 DMA */
	ADC_DMACmd(ADC_USED, ENABLE);	
	/* Enable ADC1 */
	ADC_Cmd(ADC_USED, ENABLE);	
	/*复位校准寄存器 */   
	ADC_ResetCalibration(ADC_USED);
	/*等待校准寄存器复位完成 */
	while(ADC_GetResetCalibrationStatus(ADC_USED));	
	/* ADC校准 */
	ADC_StartCalibration(ADC_USED);
	/* 等待校准完成*/
	while(ADC_GetCalibrationStatus(ADC_USED));
	
	/* 由于没有采用外部触发，所以使用软件触发ADC转换 */ 
	ADC_SoftwareStartConvCmd(ADC_USED, ENABLE);
    
#endif
#ifdef _STM32F4xx_

    ADC_InitTypeDef  ADC_InitStructure;
    ADC_CommonInitTypeDef ADC_CommonInitStructure;
    
    RCC_APB2PeriphClockCmd(RCC_USED_ADC, ENABLE);
    ADC_DeInit();
    /* ADC Common Init **********************************************************/
    ADC_CommonInitStructure.ADC_Mode = ADC_Mode_Independent;//独立模式
    ADC_CommonInitStructure.ADC_Prescaler = ADC_Prescaler_Div4;//4分频
    ADC_CommonInitStructure.ADC_DMAAccessMode = ADC_DMAAccessMode_Disabled;//关闭DMA闪取
    ADC_CommonInitStructure.ADC_TwoSamplingDelay = ADC_TwoSamplingDelay_9Cycles;//采样间隔
    ADC_CommonInit(&ADC_CommonInitStructure);
    /* ADC Init ****************************************************************/
    ADC_InitStructure.ADC_Resolution = ADC_Resolution_12b;//12位转换方式
    ADC_InitStructure.ADC_ScanConvMode = ENABLE;//扫描模式
    ADC_InitStructure.ADC_ContinuousConvMode = ENABLE;//连续模式 
    ADC_InitStructure.ADC_ExternalTrigConvEdge = ADC_ExternalTrigConvEdge_None;
    ADC_InitStructure.ADC_DataAlign = ADC_DataAlign_Right;
    ADC_InitStructure.ADC_NbrOfConversion = 4;//多通道转换时应修改此处
    ADC_Init(USED_ADC, &ADC_InitStructure);
    /* ADC regular channel12 configuration *************************************/
    ADC_RegularChannelConfig(USED_ADC, ADC_Channel_1, 1, ADC_SampleTime_84Cycles);//设置ADC常规通道序列
    ADC_RegularChannelConfig(USED_ADC, ADC_Channel_2, 2, ADC_SampleTime_84Cycles);//设置ADC常规通道序列
    ADC_RegularChannelConfig(USED_ADC, ADC_Channel_1, 3, ADC_SampleTime_84Cycles);//设置ADC常规通道序列
    ADC_RegularChannelConfig(USED_ADC, ADC_Channel_2, 4, ADC_SampleTime_84Cycles);//设置ADC常规通道序列

    /* Enable DMA request after last transfer (Single-ADC mode) */
    ADC_DMARequestAfterLastTransferCmd(USED_ADC, ENABLE);//ADC转换完成后立即启//动DMA功能
    /* Enable ADC DMA */
    ADC_DMACmd(USED_ADC, ENABLE);
    /* Enable ADC*/
    ADC_Cmd(USED_ADC, ENABLE); 
    //软件启动ADC  
    ADC_SoftwareStartConv(USED_ADC);   
#endif    
}
/*
 *@ <function name=>ADC_DMA_Config() </function>
 *@ <summary>
    ADC DMA配置
 *@ </summary>
 *@ <param name="xxx"></param>
 *@ <returns> </returns>
*/
static void ADC_DMA_Config(void)
{
#ifdef _STM32F10x_
	DMA_InitTypeDef DMA_InitStructure;
    RCC_AHBPeriphClockCmd(RCC_ADC_DMA, ENABLE);

	/* DMA channel1 configuration */
	DMA_DeInit(ADC_DMA_Channel);	
	DMA_InitStructure.DMA_PeripheralBaseAddr = ADC_USED_DR;	 			//ADC地址
	DMA_InitStructure.DMA_MemoryBaseAddr = (u32)ADC_USED_ConvertedValue1;	//内存地址
	DMA_InitStructure.DMA_DIR = DMA_DIR_PeripheralSRC;
	DMA_InitStructure.DMA_BufferSize = ADC_Converted_Num;
	DMA_InitStructure.DMA_PeripheralInc = DMA_PeripheralInc_Disable;	//外设地址固定
	DMA_InitStructure.DMA_MemoryInc = DMA_MemoryInc_Enable;  				//内存地址
	DMA_InitStructure.DMA_PeripheralDataSize = DMA_PeripheralDataSize_HalfWord;	//半字
	DMA_InitStructure.DMA_MemoryDataSize = DMA_MemoryDataSize_HalfWord;
	DMA_InitStructure.DMA_Mode = DMA_Mode_Circular;										//循环传输
	DMA_InitStructure.DMA_Priority = DMA_Priority_High;
	DMA_InitStructure.DMA_M2M = DMA_M2M_Disable;
	DMA_Init(ADC_DMA_Channel, &DMA_InitStructure);
//    DMA_ITConfig(ADC_DMA_Channel,DMA_IT_TC,ENABLE);
	
	/* Enable DMA channel1 */
	DMA_Cmd(ADC_DMA_Channel, ENABLE);
    
#endif
#ifdef _STM32F4xx_
    DMA_InitTypeDef DMA_InitStructure;
    /* Enable ADC3, DMA2 and GPIO clocks ****************************************/
    RCC_AHB1PeriphClockCmd(RCC_AHB1Periph_DMA2, ENABLE);
    DMA_DeInit(DMA2_Stream0);
    /* DMA2 Stream0 channel0 configuration **************************************/
    DMA_InitStructure.DMA_Channel = DMA_Channel_0;
    DMA_InitStructure.DMA_PeripheralBaseAddr = (uint32_t)(&ADC1->DR);
    DMA_InitStructure.DMA_Memory0BaseAddr = (uint32_t)ADC_USED_ConvertedValue1;
    DMA_InitStructure.DMA_DIR = DMA_DIR_PeripheralToMemory; //设置DMA方向为外设//到内存
    DMA_InitStructure.DMA_BufferSize = ADC_Converted_Num;//多通道采样时需要修改
    DMA_InitStructure.DMA_PeripheralInc = DMA_PeripheralInc_Disable;//外设地址不动
    DMA_InitStructure.DMA_MemoryInc = DMA_MemoryInc_Enable;//物理地址++
    DMA_InitStructure.DMA_PeripheralDataSize = DMA_PeripheralDataSize_HalfWord;
    DMA_InitStructure.DMA_MemoryDataSize = DMA_MemoryDataSize_HalfWord;  //半字方//式
    DMA_InitStructure.DMA_Mode = DMA_Mode_Circular;
    DMA_InitStructure.DMA_Priority = DMA_Priority_High;
    DMA_InitStructure.DMA_FIFOMode = DMA_FIFOMode_Disable;
    DMA_InitStructure.DMA_FIFOThreshold = DMA_FIFOThreshold_HalfFull;
    DMA_InitStructure.DMA_MemoryBurst = DMA_MemoryBurst_Single;
    DMA_InitStructure.DMA_PeripheralBurst = DMA_PeripheralBurst_Single;
//    DMA_DoubleBufferModeConfig(DMA2_Stream0, (uint32_t)ADC_USED_ConvertedValue2, DMA_Memory_0);
    DMA_DoubleBufferModeCmd(DMA2_Stream0, ENABLE);
    
    DMA_Init(DMA2_Stream0, &DMA_InitStructure);
    DMA_ITConfig(DMA2_Stream0,DMA_IT_TC|DMA_IT_HT,ENABLE);
    DMA_Cmd(DMA2_Stream0, ENABLE); 
#endif    
}
/*
 *@ <function name=>DMA_ADC_NVIC() </function>
 *@ <summary>
    ADC DMA中断配置
 *@ </summary>
 *@ <param name="prePriority">抢占优先级</param>
 *@ <param name="subPriority">附属优先级</param>
 *@ <returns> </returns>
*/
void DMA_ADC_NVIC(u8 prePriority,u8 subPriority)
{
#ifdef _STM32F4xx_
	NVIC_InitTypeDef NVIC_InitStructure;
    NVIC_InitStructure.NVIC_IRQChannel = DMA2_Stream0_IRQn;
	NVIC_InitStructure.NVIC_IRQChannelPreemptionPriority = prePriority;  
	NVIC_InitStructure.NVIC_IRQChannelSubPriority = subPriority; 
	NVIC_InitStructure.NVIC_IRQChannelCmd = ENABLE; 
	NVIC_Init(&NVIC_InitStructure);
#endif
}
/*
 *@ <function name=>DMA_ADC_IRQPendle() </function>
 *@ <summary>
    ADC DMA传输中断子函数,在stm32f4xx_t.c中调用
 *@ </summary>
 *@ <param name="xxx"></param>
 *@ <returns> </returns>
*/
void DMA_ADC_IRQPendle(void)
{
#ifdef _STM32F4xx_
    if(DMA_GetITStatus(DMA2_Stream0,DMA_IT_TCIF0))
    {
        DMA_ClearITPendingBit(DMA2_Stream0,DMA_IT_TCIF0);
        DMA_TC_Flag = 1;
    }
    if(DMA_GetITStatus(DMA2_Stream0,DMA_IT_HTIF0))
    {
        DMA_ClearITPendingBit(DMA2_Stream0,DMA_IT_HTIF0);
//        DMA_HT_Flag = 1;
    } 
#endif
#ifdef _STM32F10x_
    if(DMA_GetITStatus(DMA1_IT_TC1))
    {
        DMA_ClearITPendingBit(DMA1_IT_TC1);
        DMA_TC_Flag = 1;
    }


#endif    
}
/*
 *@ <function name=>Get_ADC_Value() </function>
 *@ <summary>
    获取ADC的采样值
 *@ </summary>
 *@ <param name="xxx"></param>
 *@ <returns> </returns>
*/
s16 Get_ADC_Value(void)
{
    u32 temp = 0;
    float temp_sesult = 0;
    for(u8 ii = 0;ii<ADC_Converted_Num;ii++)
    {
        temp += ADC_USED_ConvertedValue1[ii];
    }
    temp_sesult = 1.0*temp/ADC_Converted_Num;
    temp_sesult = 4*temp_sesult - 12498;
    
    return ((s16)temp_sesult + 1000);
}
/**************************End of this file***************************************



                                          Copyright @JohnBee */
