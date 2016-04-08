/********************************************************************************
 *@FileName    bsp_init.c
 *@Author      Johnbee
 *@Version     V0.1
 *@Date        2015/10/02
 *@Brief       用于各种硬件初始化
 *******************************************************************************/
/*#includes*********************************************************************/
#include "bsp_init.h"

/*#define***********************************************************************/
#ifdef  _STM32F10x_
#define KeyA_Port              GPIOC
#define KeyA_Pin               GPIO_Pin_13
#define KeyA_Exit_Line         EXTI_Line13
#define KeyA_GPIO_PinSource    GPIO_PinSource13
#define KeyA_GPIO_PortSource   GPIO_PortSourceGPIOC
#define RCC_KeyA_Port          RCC_APB2Periph_GPIOC// | RCC_APB2Periph_AFIO

//#define KeyB_Port              GPIOA
//#define KeyB_Pin               GPIO_Pin_5
//#define KeyB_Exit_Line         EXTI_Line5
//#define KeyB_GPIO_PinSource    GPIO_PinSource5
//#define KeyB_GPIO_PortSource   GPIO_PortSourceGPIOA
//#define RCC_KeyB_Port          RCC_APB2Periph_GPIOA // | RCC_APB2Periph_AFIO

//#define KeyC_Port              GPIOA
//#define KeyC_Pin               GPIO_Pin_6
//#define KeyC_Exit_Line         EXTI_Line6
//#define KeyC_GPIO_PinSource    GPIO_PinSource6
//#define KeyC_GPIO_PortSource   GPIO_PortSourceGPIOA
//#define RCC_KeyC_Port          RCC_APB2Periph_GPIOA  //| RCC_APB2Periph_AFIO
#endif
#ifdef  _STM32F4xx_
#define      RLED_Port          GPIOC
#define      RLED_Pin           GPIO_Pin_11
#define      GLED_Port          GPIOC
#define      GLED_Pin           GPIO_Pin_10
#define      BLED_Port          GPIOA
#define      BLED_Pin           GPIO_Pin_15
#define      RCC_LED_Port       RCC_AHB1Periph_GPIOA|RCC_AHB1Periph_GPIOC

#endif


/*全局变量声明******************************************************************/


/********************************************************************************
 *@函数名称    BSP_Init()
 *@函数功能    各种硬件配置和初始化
 *@入口参数    无
 *@出口参数    无
 *******************************************************************************/
void Bsp_Init(void)
{
    Bsp_NVIC_Config();/*中断配置*/

    TIM1_PWM_Config();
    BlueToothInit();
    Bsp_ADC_Init();
    Bsp_Encoder_Config();
    Bsp_LED_Init();
//    Bsp_CAN_Init();

    while (Current_CalibrateState == 0); //等待电流零点校准完成
}
/********************************************************************************
 *@函数名称    Bsp_NVIC_Config()
 *@函数功能    中断向量表配置
 *@入口参数    无
 *@出口参数    无
 *@说    明    所有的工程的中断都要在此配置
 *******************************************************************************/
void Bsp_NVIC_Config(void)
{

    /*中断分组配置*/
    NVIC_PriorityGroupConfig(NVIC_PriorityGroup_4);

    Hall_TIM_NVIC_Config(0, 0);
    TIM1_TRG_COM_NVIC_Config(1, 0);
    BLE_NVIC_Config(2, 0);
    DMA_Phase_ADC_NVIC(3, 0);
    DMA_Current_ADC_NVIC(4, 0);
}

/********************************************************************************
 *@函数名称    SysTick_init()
 *@函数功能    初始化SysTick定时器
 *@入口参数    无
 *@出口参数    无
 *******************************************************************************/
void SysTick_init(void)
{
    RCC_ClocksTypeDef  rcc_clocks;
    RCC_GetClocksFreq(&rcc_clocks); /*获取系统主频*/
    /*systick的中断函数是用来切换任务的*/
//    SysTick_Config(rcc_clocks.HCLK_Frequency/OS_TICKS_PER_SEC);//初始化并使能SysTick定时器
}
/*
 *@ <function name=> Bsp_LED_Init() </function>
 *@ <summary>
     config the gpio for the state LED
 *@ </summary>
 *@ <param name="void">null</param>
 *@ <returns> null </returns>
 */
void Bsp_LED_Init(void)
{
    GPIO_InitTypeDef GPIO_InitStructure;
    RCC_AHB1PeriphClockCmd(RCC_LED_Port, ENABLE);
    GPIO_InitStructure.GPIO_Mode = GPIO_Mode_OUT;
    GPIO_InitStructure.GPIO_OType = GPIO_OType_OD;
    GPIO_InitStructure.GPIO_Speed = GPIO_Speed_50MHz;
    GPIO_InitStructure.GPIO_PuPd = GPIO_PuPd_UP;
    GPIO_InitStructure.GPIO_Pin = RLED_Pin;
    GPIO_Init(RLED_Port, &GPIO_InitStructure);

    GPIO_InitStructure.GPIO_Pin = GLED_Pin;
    GPIO_Init(GLED_Port, &GPIO_InitStructure);
    GPIO_InitStructure.GPIO_Pin = BLED_Pin;
    GPIO_Init(BLED_Port, &GPIO_InitStructure);
}
void Set_LED(u8 led, u8 state)
{
    GPIO_TypeDef * led_port;
    uint16_t led_pin;
    u8 led_flag;
    if (led == RedLed)
    {
        led_port = RLED_Port;
        led_pin = RLED_Pin;
    }
    else if (led == GreenLed)
    {
        led_port = GLED_Port;
        led_pin = GLED_Pin;
    }
    else if (led == BlueLed)
    {
        led_port = BLED_Port;
        led_pin = BLED_Pin;
    }
    if (state == Led_ON)
    {
        led_flag = Bit_SET;
    }
    else
    {
        led_flag = Bit_RESET;
    }
    GPIO_WriteBit(led_port,led_pin,led_flag);
}
/*
 *@ <function name=>Key_GPIO_Init() </function>
 *@ <summary>
     config the gpio for the presskey
 *@ </summary>
 *@ <param name="void">null</param>
 *@ <returns> null </returns>
 */
void Key_GPIO_Init(void)
{

#ifdef  _STM32F10x_
    EXTI_InitTypeDef EXTI_InitStructure;
    GPIO_InitTypeDef GPIO_InitStructure;
    RCC_APB2PeriphClockCmd(RCC_KeyA_Port , ENABLE);

    GPIO_InitStructure.GPIO_Pin = KeyA_Pin;
    GPIO_InitStructure.GPIO_Mode = GPIO_Mode_IPD;	 // 上拉输入
    GPIO_Init(KeyA_Port, &GPIO_InitStructure);

//    GPIO_InitStructure.GPIO_Pin = KeyB_Pin;
//    GPIO_Init(KeyB_Port, &GPIO_InitStructure);

//    GPIO_InitStructure.GPIO_Pin = KeyC_Pin;
//    GPIO_Init(KeyC_Port, &GPIO_InitStructure);

    /* EXTI line mode config */
    GPIO_EXTILineConfig(KeyA_GPIO_PortSource, KeyA_GPIO_PinSource);
    EXTI_InitStructure.EXTI_Line = KeyA_Exit_Line;
    EXTI_InitStructure.EXTI_Mode = EXTI_Mode_Interrupt;
    EXTI_InitStructure.EXTI_Trigger = EXTI_Trigger_Falling; //下降沿中断
//    EXTI_InitStructure.EXTI_Trigger = EXTI_Trigger_Rising_Falling; //上下沿中断
    EXTI_InitStructure.EXTI_LineCmd = ENABLE;
    EXTI_Init(&EXTI_InitStructure);

//    GPIO_EXTILineConfig(KeyB_GPIO_PortSource, KeyB_GPIO_PinSource);
//    EXTI_InitStructure.EXTI_Line = KeyB_Exit_Line;
//    EXTI_Init(&EXTI_InitStructure);
//    GPIO_EXTILineConfig(KeyC_GPIO_PortSource, KeyC_GPIO_PinSource);
//    EXTI_InitStructure.EXTI_Line = KeyC_Exit_Line;
//    EXTI_Init(&EXTI_InitStructure);
#endif

#ifdef _STM32F4xx_
    //还没写
#endif
}
/*
 *@ <function name=>EXTI15_10_NVIC_Config() </function>
 *@ <summary>
      按键中断配置
 *@ </summary>
 *@ <param name="preemPriority">抢占优先级</param>
 *@ <param name="subPriority">附属优先级</param>
 *@ <returns> null </returns>
 */
void EXTI15_10_NVIC_Config(u8 preemPriority, u8 subPriority)
{
    NVIC_InitTypeDef NVIC_InitStructure;
    NVIC_InitStructure.NVIC_IRQChannel = EXTI15_10_IRQn;
    NVIC_InitStructure.NVIC_IRQChannelPreemptionPriority = preemPriority;
    NVIC_InitStructure.NVIC_IRQChannelSubPriority = subPriority;
    NVIC_InitStructure.NVIC_IRQChannelCmd = ENABLE;
    NVIC_Init(&NVIC_InitStructure);
}
/****************** end of this file ********************************************


                                                             Copyright @JohnBee */
