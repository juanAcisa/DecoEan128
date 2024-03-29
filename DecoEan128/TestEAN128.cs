﻿using System;
using System.Text.RegularExpressions;

namespace EAN128
{
    /// <summary>
    /// Decodificacion EAN128 en AI (Identificadores aplicación)
    /// </summary>
    /// <autor>
    /// juan.acisa@gmail.com
    /// </autor>
    /// <date>
    /// 20190901D1819
    /// </date>


    public class Ean128
    {
        public struct ApplicationIdentifiers
        {
            public string codigo;
            public string descripcion;
            public string formato;
            public string titulo;
            public string fnc;
            public string regExp;
            public string valorCadena;
            public double valorDouble;
            public ApplicationIdentifiers(string pCodigo, string pDescripcion, string pFormato, string pTitulo, string pFnc, string pRegExp, string pValorCadena, double pValorDouble)
            {
                codigo = pCodigo;
                descripcion = pDescripcion;
                formato = pFormato;
                titulo = pTitulo;
                fnc = pFnc;
                regExp = pRegExp;
                valorCadena = pValorCadena;
                valorDouble = pValorDouble;
            }
        }
        private static ApplicationIdentifiers[] ia = new ApplicationIdentifiers[512];

        #region Propiedades
        private string AI_00___Código_Seriado_de_Contenedor_de_Embarque_SSCC_;
        private string AI_01___Número_Global_de_Artículo_Comercial_GTIN_;
        private string AI_02___GTIN_de_los_artículos_comerciales_contenidos;
        private string AI_10___Lote_o_número_de_lote;
        private string AI_11___Fecha_de_producción_AAMMDD_;
        private string AI_12___Fecha_de_vencimiento_de_pago_AAMMDD_;
        private string AI_13___Fecha_de_envasado_AAMMDD_;
        private string AI_15___Fecha_de_consumo_preferente_AAMMDD_;
        private string AI_16___Última_fecha_de_venta_AAMMDD_;
        private string AI_17___Fecha_de_vencimiento_AAMMDD_;
        private string AI_20___Variante_de_producto_interno;
        private string AI_21___Número_de_serie;
        private string AI_22___Variante_de_producto_de_consumo;
        private string AI_235__Extensión_serializada_controlada_de_GTIN_de_terceros_TPX_;
        private string AI_240__Identificación_de_producto_adicional_asignado_por_el_fabricante;
        private string AI_241__Número_de_pieza_del_cliente;
        private string AI_242__Número_de_variación_de_mandado_a_hacer;
        private string AI_243__Número_de_componente_de_empaque;
        private string AI_250__Número_de_serie_secundario;
        private string AI_251__Referencia_a_la_entidad_de_origen;
        private string AI_253__Identificador_de_tipo_de_documento_global_GDTI_;
        private string AI_254__Componente_de_extensión_del_GLN;
        private string AI_255__Número_de_cupón_global_GCN_;
        private string AI_30___Conteo_variable_de_artículos_artículo_comercial_de_medidas_variables_;
        private string AI_3100_Peso_neto_kilogramos__artículo_comercial_de_medidas_variables_;
        private string AI_3101_Peso_neto_kilogramos__artículo_comercial_de_medidas_variables_;
        private string AI_3102_Peso_neto_kilogramos__artículo_comercial_de_medidas_variables_;
        private string AI_3103_Peso_neto_kilogramos__artículo_comercial_de_medidas_variables_;
        private string AI_3104_Peso_neto_kilogramos__artículo_comercial_de_medidas_variables_;
        private string AI_3105_Peso_neto_kilogramos__artículo_comercial_de_medidas_variables_;
        private string AI_3110_Longitud_o_primera_dimensión_metros__artículo_comercial_de_medidas_variables_;
        private string AI_3111_Longitud_o_primera_dimensión_metros__artículo_comercial_de_medidas_variables_;
        private string AI_3112_Longitud_o_primera_dimensión_metros__artículo_comercial_de_medidas_variables_;
        private string AI_3113_Longitud_o_primera_dimensión_metros__artículo_comercial_de_medidas_variables_;
        private string AI_3114_Longitud_o_primera_dimensión_metros__artículo_comercial_de_medidas_variables_;
        private string AI_3115_Longitud_o_primera_dimensión_metros__artículo_comercial_de_medidas_variables_;
        private string AI_3120_Ancho_diámetro_o_segunda_dimensión_metros__artículo_comercial_de_medidas_variables_;
        private string AI_3121_Ancho_diámetro_o_segunda_dimensión_metros__artículo_comercial_de_medidas_variables_;
        private string AI_3122_Ancho_diámetro_o_segunda_dimensión_metros__artículo_comercial_de_medidas_variables_;
        private string AI_3123_Ancho_diámetro_o_segunda_dimensión_metros__artículo_comercial_de_medidas_variables_;
        private string AI_3124_Ancho_diámetro_o_segunda_dimensión_metros__artículo_comercial_de_medidas_variables_;
        private string AI_3125_Ancho_diámetro_o_segunda_dimensión_metros__artículo_comercial_de_medidas_variables_;
        private string AI_3130_Profundidad_grosor_altura_o_tercera_dimensión_metros__artículo_comercial_de_medidas_variables_;
        private string AI_3131_Profundidad_grosor_altura_o_tercera_dimensión_metros__artículo_comercial_de_medidas_variables_;
        private string AI_3132_Profundidad_grosor_altura_o_tercera_dimensión_metros__artículo_comercial_de_medidas_variables_;
        private string AI_3133_Profundidad_grosor_altura_o_tercera_dimensión_metros__artículo_comercial_de_medidas_variables_;
        private string AI_3134_Profundidad_grosor_altura_o_tercera_dimensión_metros__artículo_comercial_de_medidas_variables_;
        private string AI_3135_Profundidad_grosor_altura_o_tercera_dimensión_metros__artículo_comercial_de_medidas_variables_;
        private string AI_3140_Área_metros_cuadrados__artículo_comercial_de_medidas_variables_;
        private string AI_3141_Área_metros_cuadrados__artículo_comercial_de_medidas_variables_;
        private string AI_3142_Área_metros_cuadrados__artículo_comercial_de_medidas_variables_;
        private string AI_3143_Área_metros_cuadrados__artículo_comercial_de_medidas_variables_;
        private string AI_3144_Área_metros_cuadrados__artículo_comercial_de_medidas_variables_;
        private string AI_3145_Área_metros_cuadrados__artículo_comercial_de_medidas_variables_;
        private string AI_3150_Volumen_neto_litros__artículo_comercial_de_medidas_variables_;
        private string AI_3151_Volumen_neto_litros__artículo_comercial_de_medidas_variables_;
        private string AI_3152_Volumen_neto_litros__artículo_comercial_de_medidas_variables_;
        private string AI_3153_Volumen_neto_litros__artículo_comercial_de_medidas_variables_;
        private string AI_3154_Volumen_neto_litros__artículo_comercial_de_medidas_variables_;
        private string AI_3155_Volumen_neto_litros__artículo_comercial_de_medidas_variables_;
        private string AI_3160_Volumen_neto_metros_cúbicos__artículo_comercial_de_medidas_variables_;
        private string AI_3161_Volumen_neto_metros_cúbicos__artículo_comercial_de_medidas_variables_;
        private string AI_3162_Volumen_neto_metros_cúbicos__artículo_comercial_de_medidas_variables_;
        private string AI_3163_Volumen_neto_metros_cúbicos__artículo_comercial_de_medidas_variables_;
        private string AI_3164_Volumen_neto_metros_cúbicos__artículo_comercial_de_medidas_variables_;
        private string AI_3165_Volumen_neto_metros_cúbicos__artículo_comercial_de_medidas_variables_;
        private string AI_3200_Peso_neto_libras__artículo_comercial_de_medidas_variables_;
        private string AI_3201_Peso_neto_libras__artículo_comercial_de_medidas_variables_;
        private string AI_3202_Peso_neto_libras__artículo_comercial_de_medidas_variables_;
        private string AI_3203_Peso_neto_libras__artículo_comercial_de_medidas_variables_;
        private string AI_3204_Peso_neto_libras__artículo_comercial_de_medidas_variables_;
        private string AI_3205_Peso_neto_libras__artículo_comercial_de_medidas_variables_;
        private string AI_3210_Longitud_o_primera_dimensión_pulgadas__artículo_comercial_de_medidas_variables_;
        private string AI_3211_Longitud_o_primera_dimensión_pulgadas__artículo_comercial_de_medidas_variables_;
        private string AI_3212_Longitud_o_primera_dimensión_pulgadas__artículo_comercial_de_medidas_variables_;
        private string AI_3213_Longitud_o_primera_dimensión_pulgadas__artículo_comercial_de_medidas_variables_;
        private string AI_3214_Longitud_o_primera_dimensión_pulgadas__artículo_comercial_de_medidas_variables_;
        private string AI_3215_Longitud_o_primera_dimensión_pulgadas__artículo_comercial_de_medidas_variables_;
        private string AI_3220_Longitud_o_primera_dimensión_pies__artículo_comercial_de_medidas_variables_;
        private string AI_3221_Longitud_o_primera_dimensión_pies__artículo_comercial_de_medidas_variables_;
        private string AI_3222_Longitud_o_primera_dimensión_pies__artículo_comercial_de_medidas_variables_;
        private string AI_3223_Longitud_o_primera_dimensión_pies__artículo_comercial_de_medidas_variables_;
        private string AI_3224_Longitud_o_primera_dimensión_pies__artículo_comercial_de_medidas_variables_;
        private string AI_3225_Longitud_o_primera_dimensión_pies__artículo_comercial_de_medidas_variables_;
        private string AI_3230_Longitud_o_primera_dimensión_yardas__artículo_comercial_de_medidas_variables_;
        private string AI_3231_Longitud_o_primera_dimensión_yardas__artículo_comercial_de_medidas_variables_;
        private string AI_3232_Longitud_o_primera_dimensión_yardas__artículo_comercial_de_medidas_variables_;
        private string AI_3233_Longitud_o_primera_dimensión_yardas__artículo_comercial_de_medidas_variables_;
        private string AI_3234_Longitud_o_primera_dimensión_yardas__artículo_comercial_de_medidas_variables_;
        private string AI_3235_Longitud_o_primera_dimensión_yardas__artículo_comercial_de_medidas_variables_;
        private string AI_3240_Ancho_diámetro_o_segunda_dimensión_pulgadas__artículo_comercial_de_medidas_variables_;
        private string AI_3241_Ancho_diámetro_o_segunda_dimensión_pulgadas__artículo_comercial_de_medidas_variables_;
        private string AI_3242_Ancho_diámetro_o_segunda_dimensión_pulgadas__artículo_comercial_de_medidas_variables_;
        private string AI_3243_Ancho_diámetro_o_segunda_dimensión_pulgadas__artículo_comercial_de_medidas_variables_;
        private string AI_3244_Ancho_diámetro_o_segunda_dimensión_pulgadas__artículo_comercial_de_medidas_variables_;
        private string AI_3245_Ancho_diámetro_o_segunda_dimensión_pulgadas__artículo_comercial_de_medidas_variables_;
        private string AI_3250_Ancho_diámetro_o_segunda_dimensión_pies__artículo_comercial_de_medidas_variables_;
        private string AI_3251_Ancho_diámetro_o_segunda_dimensión_pies__artículo_comercial_de_medidas_variables_;
        private string AI_3252_Ancho_diámetro_o_segunda_dimensión_pies__artículo_comercial_de_medidas_variables_;
        private string AI_3253_Ancho_diámetro_o_segunda_dimensión_pies__artículo_comercial_de_medidas_variables_;
        private string AI_3254_Ancho_diámetro_o_segunda_dimensión_pies__artículo_comercial_de_medidas_variables_;
        private string AI_3255_Ancho_diámetro_o_segunda_dimensión_pies__artículo_comercial_de_medidas_variables_;
        private string AI_3260_Ancho_diámetro_o_segunda_dimensión_yardas__artículo_comercial_de_medidas_variables_;
        private string AI_3261_Ancho_diámetro_o_segunda_dimensión_yardas__artículo_comercial_de_medidas_variables_;
        private string AI_3262_Ancho_diámetro_o_segunda_dimensión_yardas__artículo_comercial_de_medidas_variables_;
        private string AI_3263_Ancho_diámetro_o_segunda_dimensión_yardas__artículo_comercial_de_medidas_variables_;
        private string AI_3264_Ancho_diámetro_o_segunda_dimensión_yardas__artículo_comercial_de_medidas_variables_;
        private string AI_3265_Ancho_diámetro_o_segunda_dimensión_yardas__artículo_comercial_de_medidas_variables_;
        private string AI_3270_Profundidad_grosor_altura_o_tercera_dimensión_pulgadas__artículo_comercial_de_medidas_variables_;
        private string AI_3271_Profundidad_grosor_altura_o_tercera_dimensión_pulgadas__artículo_comercial_de_medidas_variables_;
        private string AI_3272_Profundidad_grosor_altura_o_tercera_dimensión_pulgadas__artículo_comercial_de_medidas_variables_;
        private string AI_3273_Profundidad_grosor_altura_o_tercera_dimensión_pulgadas__artículo_comercial_de_medidas_variables_;
        private string AI_3274_Profundidad_grosor_altura_o_tercera_dimensión_pulgadas__artículo_comercial_de_medidas_variables_;
        private string AI_3275_Profundidad_grosor_altura_o_tercera_dimensión_pulgadas__artículo_comercial_de_medidas_variables_;
        private string AI_3280_Profundidad_grosor_altura_o_tercera_dimensión_pies__artículo_comercial_de_medidas_variables_;
        private string AI_3281_Profundidad_grosor_altura_o_tercera_dimensión_pies__artículo_comercial_de_medidas_variables_;
        private string AI_3282_Profundidad_grosor_altura_o_tercera_dimensión_pies__artículo_comercial_de_medidas_variables_;
        private string AI_3283_Profundidad_grosor_altura_o_tercera_dimensión_pies__artículo_comercial_de_medidas_variables_;
        private string AI_3284_Profundidad_grosor_altura_o_tercera_dimensión_pies__artículo_comercial_de_medidas_variables_;
        private string AI_3285_Profundidad_grosor_altura_o_tercera_dimensión_pies__artículo_comercial_de_medidas_variables_;
        private string AI_3290_Profundidad_grosor_altura_o_tercera_dimensión_yardas__artículo_comercial_de_medidas_variables_;
        private string AI_3291_Profundidad_grosor_altura_o_tercera_dimensión_yardas__artículo_comercial_de_medidas_variables_;
        private string AI_3292_Profundidad_grosor_altura_o_tercera_dimensión_yardas__artículo_comercial_de_medidas_variables_;
        private string AI_3293_Profundidad_grosor_altura_o_tercera_dimensión_yardas__artículo_comercial_de_medidas_variables_;
        private string AI_3294_Profundidad_grosor_altura_o_tercera_dimensión_yardas__artículo_comercial_de_medidas_variables_;
        private string AI_3295_Profundidad_grosor_altura_o_tercera_dimensión_yardas__artículo_comercial_de_medidas_variables_;
        private string AI_3300_Peso_logístico_kilogramos;
        private string AI_3301_Peso_logístico_kilogramos;
        private string AI_3302_Peso_logístico_kilogramos;
        private string AI_3303_Peso_logístico_kilogramos;
        private string AI_3304_Peso_logístico_kilogramos;
        private string AI_3305_Peso_logístico_kilogramos;
        private string AI_3310_Longitud_o_primera_dimensión_metros;
        private string AI_3311_Longitud_o_primera_dimensión_metros;
        private string AI_3312_Longitud_o_primera_dimensión_metros;
        private string AI_3313_Longitud_o_primera_dimensión_metros;
        private string AI_3314_Longitud_o_primera_dimensión_metros;
        private string AI_3315_Longitud_o_primera_dimensión_metros;
        private string AI_3320_Ancho_diámetro_o_segunda_dimensión_metros;
        private string AI_3321_Ancho_diámetro_o_segunda_dimensión_metros;
        private string AI_3322_Ancho_diámetro_o_segunda_dimensión_metros;
        private string AI_3323_Ancho_diámetro_o_segunda_dimensión_metros;
        private string AI_3324_Ancho_diámetro_o_segunda_dimensión_metros;
        private string AI_3325_Ancho_diámetro_o_segunda_dimensión_metros;
        private string AI_3330_Profundidad_grosor_altura_o_tercera_dimensión_metros;
        private string AI_3331_Profundidad_grosor_altura_o_tercera_dimensión_metros;
        private string AI_3332_Profundidad_grosor_altura_o_tercera_dimensión_metros;
        private string AI_3333_Profundidad_grosor_altura_o_tercera_dimensión_metros;
        private string AI_3334_Profundidad_grosor_altura_o_tercera_dimensión_metros;
        private string AI_3335_Profundidad_grosor_altura_o_tercera_dimensión_metros;
        private string AI_3340_Área_metros_cuadrados;
        private string AI_3341_Área_metros_cuadrados;
        private string AI_3342_Área_metros_cuadrados;
        private string AI_3343_Área_metros_cuadrados;
        private string AI_3344_Área_metros_cuadrados;
        private string AI_3345_Área_metros_cuadrados;
        private string AI_3350_Volumen_logístico_litros;
        private string AI_3351_Volumen_logístico_litros;
        private string AI_3352_Volumen_logístico_litros;
        private string AI_3353_Volumen_logístico_litros;
        private string AI_3354_Volumen_logístico_litros;
        private string AI_3355_Volumen_logístico_litros;
        private string AI_3360_Volumen_logístico_metros_cúbicos;
        private string AI_3361_Volumen_logístico_metros_cúbicos;
        private string AI_3362_Volumen_logístico_metros_cúbicos;
        private string AI_3363_Volumen_logístico_metros_cúbicos;
        private string AI_3364_Volumen_logístico_metros_cúbicos;
        private string AI_3365_Volumen_logístico_metros_cúbicos;
        private string AI_3370_Kilogramos_por_metro_cuadrado;
        private string AI_3371_Kilogramos_por_metro_cuadrado;
        private string AI_3372_Kilogramos_por_metro_cuadrado;
        private string AI_3373_Kilogramos_por_metro_cuadrado;
        private string AI_3374_Kilogramos_por_metro_cuadrado;
        private string AI_3375_Kilogramos_por_metro_cuadrado;
        private string AI_3400_Peso_logístico_libras;
        private string AI_3401_Peso_logístico_libras;
        private string AI_3402_Peso_logístico_libras;
        private string AI_3403_Peso_logístico_libras;
        private string AI_3404_Peso_logístico_libras;
        private string AI_3405_Peso_logístico_libras;
        private string AI_3410_Longitud_o_primera_dimensión_pulgadas;
        private string AI_3411_Longitud_o_primera_dimensión_pulgadas;
        private string AI_3412_Longitud_o_primera_dimensión_pulgadas;
        private string AI_3413_Longitud_o_primera_dimensión_pulgadas;
        private string AI_3414_Longitud_o_primera_dimensión_pulgadas;
        private string AI_3415_Longitud_o_primera_dimensión_pulgadas;
        private string AI_3420_Longitud_o_primera_dimensión_pies;
        private string AI_3421_Longitud_o_primera_dimensión_pies;
        private string AI_3422_Longitud_o_primera_dimensión_pies;
        private string AI_3423_Longitud_o_primera_dimensión_pies;
        private string AI_3424_Longitud_o_primera_dimensión_pies;
        private string AI_3425_Longitud_o_primera_dimensión_pies;
        private string AI_3430_Longitud_o_primera_dimensión_yardas;
        private string AI_3431_Longitud_o_primera_dimensión_yardas;
        private string AI_3432_Longitud_o_primera_dimensión_yardas;
        private string AI_3433_Longitud_o_primera_dimensión_yardas;
        private string AI_3434_Longitud_o_primera_dimensión_yardas;
        private string AI_3435_Longitud_o_primera_dimensión_yardas;
        private string AI_3440_Ancho_diámetro_o_segunda_dimensión_pulgadas;
        private string AI_3441_Ancho_diámetro_o_segunda_dimensión_pulgadas;
        private string AI_3442_Ancho_diámetro_o_segunda_dimensión_pulgadas;
        private string AI_3443_Ancho_diámetro_o_segunda_dimensión_pulgadas;
        private string AI_3444_Ancho_diámetro_o_segunda_dimensión_pulgadas;
        private string AI_3445_Ancho_diámetro_o_segunda_dimensión_pulgadas;
        private string AI_3450_Ancho_diámetro_o_segunda_dimensión_pies;
        private string AI_3452_Ancho_diámetro_o_segunda_dimensión_pies;
        private string AI_3451_Ancho_diámetro_o_segunda_dimensión_pies;
        private string AI_3453_Ancho_diámetro_o_segunda_dimensión_pies;
        private string AI_3454_Ancho_diámetro_o_segunda_dimensión_pies;
        private string AI_3455_Ancho_diámetro_o_segunda_dimensión_pies;
        private string AI_3460_Ancho_diámetro_o_segunda_dimensión_yardas;
        private string AI_3461_Ancho_diámetro_o_segunda_dimensión_yardas;
        private string AI_3462_Ancho_diámetro_o_segunda_dimensión_yardas;
        private string AI_3463_Ancho_diámetro_o_segunda_dimensión_yardas;
        private string AI_3464_Ancho_diámetro_o_segunda_dimensión_yardas;
        private string AI_3465_Ancho_diámetro_o_segunda_dimensión_yardas;
        private string AI_3470_Profundidad_grosor_altura_o_tercera_dimensión_pulgadas;
        private string AI_3471_Profundidad_grosor_altura_o_tercera_dimensión_pulgadas;
        private string AI_3472_Profundidad_grosor_altura_o_tercera_dimensión_pulgadas;
        private string AI_3473_Profundidad_grosor_altura_o_tercera_dimensión_pulgadas;
        private string AI_3474_Profundidad_grosor_altura_o_tercera_dimensión_pulgadas;
        private string AI_3475_Profundidad_grosor_altura_o_tercera_dimensión_pulgadas;
        private string AI_3480_Profundidad_grosor_altura_o_tercera_dimensión_pies;
        private string AI_3481_Profundidad_grosor_altura_o_tercera_dimensión_pies;
        private string AI_3482_Profundidad_grosor_altura_o_tercera_dimensión_pies;
        private string AI_3483_Profundidad_grosor_altura_o_tercera_dimensión_pies;
        private string AI_3484_Profundidad_grosor_altura_o_tercera_dimensión_pies;
        private string AI_3485_Profundidad_grosor_altura_o_tercera_dimensión_pies;
        private string AI_3490_Profundidad_grosor_altura_o_tercera_dimensión_yardas;
        private string AI_3491_Profundidad_grosor_altura_o_tercera_dimensión_yardas;
        private string AI_3492_Profundidad_grosor_altura_o_tercera_dimensión_yardas;
        private string AI_3493_Profundidad_grosor_altura_o_tercera_dimensión_yardas;
        private string AI_3494_Profundidad_grosor_altura_o_tercera_dimensión_yardas;
        private string AI_3495_Profundidad_grosor_altura_o_tercera_dimensión_yardas;
        private string AI_3500_Área_pulgadas_cuadradas__artículo_comercial_de_medidas_variables_;
        private string AI_3501_Área_pulgadas_cuadradas__artículo_comercial_de_medidas_variables_;
        private string AI_3502_Área_pulgadas_cuadradas__artículo_comercial_de_medidas_variables_;
        private string AI_3503_Área_pulgadas_cuadradas__artículo_comercial_de_medidas_variables_;
        private string AI_3504_Área_pulgadas_cuadradas__artículo_comercial_de_medidas_variables_;
        private string AI_3505_Área_pulgadas_cuadradas__artículo_comercial_de_medidas_variables_;
        private string AI_3510_Área_pies_cuadrados__artículo_comercial_de_medidas_variables_;
        private string AI_3511_Área_pies_cuadrados__artículo_comercial_de_medidas_variables_;
        private string AI_3512_Área_pies_cuadrados__artículo_comercial_de_medidas_variables_;
        private string AI_3513_Área_pies_cuadrados__artículo_comercial_de_medidas_variables_;
        private string AI_3514_Área_pies_cuadrados__artículo_comercial_de_medidas_variables_;
        private string AI_3515_Área_pies_cuadrados__artículo_comercial_de_medidas_variables_;
        private string AI_3520_Área_yardas_cuadradas__artículo_comercial_de_medidas_variables_;
        private string AI_3521_Área_yardas_cuadradas__artículo_comercial_de_medidas_variables_;
        private string AI_3522_Área_yardas_cuadradas__artículo_comercial_de_medidas_variables_;
        private string AI_3523_Área_yardas_cuadradas__artículo_comercial_de_medidas_variables_;
        private string AI_3524_Área_yardas_cuadradas__artículo_comercial_de_medidas_variables_;
        private string AI_3525_Área_yardas_cuadradas__artículo_comercial_de_medidas_variables_;
        private string AI_3530_Área_pulgadas_cuadradas;
        private string AI_3531_Área_pulgadas_cuadradas;
        private string AI_3532_Área_pulgadas_cuadradas;
        private string AI_3533_Área_pulgadas_cuadradas;
        private string AI_3534_Área_pulgadas_cuadradas;
        private string AI_3535_Área_pulgadas_cuadradas;
        private string AI_3540_Área_pies_cuadrados;
        private string AI_3541_Área_pies_cuadrados;
        private string AI_3542_Área_pies_cuadrados;
        private string AI_3543_Área_pies_cuadrados;
        private string AI_3544_Área_pies_cuadrados;
        private string AI_3545_Área_pies_cuadrados;
        private string AI_3550_Área_yardas_cuadradas;
        private string AI_3551_Área_yardas_cuadradas;
        private string AI_3552_Área_yardas_cuadradas;
        private string AI_3553_Área_yardas_cuadradas;
        private string AI_3554_Área_yardas_cuadradas;
        private string AI_3555_Área_yardas_cuadradas;
        private string AI_3560_Peso_neto_onzas_troy__artículo_comercial_de_medidas_variables_;
        private string AI_3561_Peso_neto_onzas_troy__artículo_comercial_de_medidas_variables_;
        private string AI_3562_Peso_neto_onzas_troy__artículo_comercial_de_medidas_variables_;
        private string AI_3563_Peso_neto_onzas_troy__artículo_comercial_de_medidas_variables_;
        private string AI_3564_Peso_neto_onzas_troy__artículo_comercial_de_medidas_variables_;
        private string AI_3565_Peso_neto_onzas_troy__artículo_comercial_de_medidas_variables_;
        private string AI_3570_Peso_neto__o_volumen__onzas__artículo_comercial_de_medidas_variables_;
        private string AI_3571_Peso_neto__o_volumen__onzas__artículo_comercial_de_medidas_variables_;
        private string AI_3572_Peso_neto__o_volumen__onzas__artículo_comercial_de_medidas_variables_;
        private string AI_3573_Peso_neto__o_volumen__onzas__artículo_comercial_de_medidas_variables_;
        private string AI_3574_Peso_neto__o_volumen__onzas__artículo_comercial_de_medidas_variables_;
        private string AI_3575_Peso_neto__o_volumen__onzas__artículo_comercial_de_medidas_variables_;
        private string AI_3600_Volumen_neto_cuartos__artículo_comercial_de_medidas_variables_;
        private string AI_3601_Volumen_neto_cuartos__artículo_comercial_de_medidas_variables_;
        private string AI_3602_Volumen_neto_cuartos__artículo_comercial_de_medidas_variables_;
        private string AI_3603_Volumen_neto_cuartos__artículo_comercial_de_medidas_variables_;
        private string AI_3604_Volumen_neto_cuartos__artículo_comercial_de_medidas_variables_;
        private string AI_3605_Volumen_neto_cuartos__artículo_comercial_de_medidas_variables_;
        private string AI_3610_Volumen_neto_galones_estadounidenses__artículo_comercial_de_medidas_variables_;
        private string AI_3611_Volumen_neto_galones_estadounidenses__artículo_comercial_de_medidas_variables_;
        private string AI_3612_Volumen_neto_galones_estadounidenses__artículo_comercial_de_medidas_variables_;
        private string AI_3613_Volumen_neto_galones_estadounidenses__artículo_comercial_de_medidas_variables_;
        private string AI_3614_Volumen_neto_galones_estadounidenses__artículo_comercial_de_medidas_variables_;
        private string AI_3615_Volumen_neto_galones_estadounidenses__artículo_comercial_de_medidas_variables_;
        private string AI_3620_Volumen_logístico_cuartos;
        private string AI_3621_Volumen_logístico_cuartos;
        private string AI_3622_Volumen_logístico_cuartos;
        private string AI_3623_Volumen_logístico_cuartos;
        private string AI_3624_Volumen_logístico_cuartos;
        private string AI_3625_Volumen_logístico_cuartos;
        private string AI_3630_Volumen_logístico_galones_estadounidenses;
        private string AI_3631_Volumen_logístico_galones_estadounidenses;
        private string AI_3632_Volumen_logístico_galones_estadounidenses;
        private string AI_3633_Volumen_logístico_galones_estadounidenses;
        private string AI_3634_Volumen_logístico_galones_estadounidenses;
        private string AI_3635_Volumen_logístico_galones_estadounidenses;
        private string AI_3640_Volumen_neto_pulgadas_cúbicas__artículo_comercial_de_medidas_variables_;
        private string AI_3641_Volumen_neto_pulgadas_cúbicas__artículo_comercial_de_medidas_variables_;
        private string AI_3642_Volumen_neto_pulgadas_cúbicas__artículo_comercial_de_medidas_variables_;
        private string AI_3643_Volumen_neto_pulgadas_cúbicas__artículo_comercial_de_medidas_variables_;
        private string AI_3644_Volumen_neto_pulgadas_cúbicas__artículo_comercial_de_medidas_variables_;
        private string AI_3645_Volumen_neto_pulgadas_cúbicas__artículo_comercial_de_medidas_variables_;
        private string AI_3650_Volumen_neto_pies_cúbicos__artículo_comercial_de_medidas_variables_;
        private string AI_3651_Volumen_neto_pies_cúbicos__artículo_comercial_de_medidas_variables_;
        private string AI_3652_Volumen_neto_pies_cúbicos__artículo_comercial_de_medidas_variables_;
        private string AI_3653_Volumen_neto_pies_cúbicos__artículo_comercial_de_medidas_variables_;
        private string AI_3654_Volumen_neto_pies_cúbicos__artículo_comercial_de_medidas_variables_;
        private string AI_3655_Volumen_neto_pies_cúbicos__artículo_comercial_de_medidas_variables_;
        private string AI_3660_Volumen_neto_yardas_cúbicas__artículo_comercial_de_medidas_variables_;
        private string AI_3661_Volumen_neto_yardas_cúbicas__artículo_comercial_de_medidas_variables_;
        private string AI_3662_Volumen_neto_yardas_cúbicas__artículo_comercial_de_medidas_variables_;
        private string AI_3663_Volumen_neto_yardas_cúbicas__artículo_comercial_de_medidas_variables_;
        private string AI_3664_Volumen_neto_yardas_cúbicas__artículo_comercial_de_medidas_variables_;
        private string AI_3665_Volumen_neto_yardas_cúbicas__artículo_comercial_de_medidas_variables_;
        private string AI_3670_Volumen_Logistic_pulgadas_cúbicas;
        private string AI_3671_Volumen_Logistic_pulgadas_cúbicas;
        private string AI_3672_Volumen_Logistic_pulgadas_cúbicas;
        private string AI_3673_Volumen_Logistic_pulgadas_cúbicas;
        private string AI_3674_Volumen_Logistic_pulgadas_cúbicas;
        private string AI_3675_Volumen_Logistic_pulgadas_cúbicas;
        private string AI_3680_Volumen_logístico_de_pies_cúbicos;
        private string AI_3681_Volumen_logístico_de_pies_cúbicos;
        private string AI_3682_Volumen_logístico_de_pies_cúbicos;
        private string AI_3683_Volumen_logístico_de_pies_cúbicos;
        private string AI_3684_Volumen_logístico_de_pies_cúbicos;
        private string AI_3685_Volumen_logístico_de_pies_cúbicos;
        private string AI_3690_Volumen_logístico_yardas_cúbicas;
        private string AI_3691_Volumen_logístico_yardas_cúbicas;
        private string AI_3692_Volumen_logístico_yardas_cúbicas;
        private string AI_3693_Volumen_logístico_yardas_cúbicas;
        private string AI_3694_Volumen_logístico_yardas_cúbicas;
        private string AI_3695_Volumen_logístico_yardas_cúbicas;
        private string AI_37___Conteo_de_artículos_comerciales_o_piezas_de_artículos_comerciales_contenidos_en_una_unidad_logística;
        private string AI_3900_Cantidad_aplicable_a_pagar_o_valor_de_cupóndescuento_moneda_local;
        private string AI_3901_Cantidad_aplicable_a_pagar_o_valor_de_cupóndescuento_moneda_local;
        private string AI_3902_Cantidad_aplicable_a_pagar_o_valor_de_cupóndescuento_moneda_local;
        private string AI_3903_Cantidad_aplicable_a_pagar_o_valor_de_cupóndescuento_moneda_local;
        private string AI_3904_Cantidad_aplicable_a_pagar_o_valor_de_cupóndescuento_moneda_local;
        private string AI_3905_Cantidad_aplicable_a_pagar_o_valor_de_cupóndescuento_moneda_local;
        private string AI_3906_Cantidad_aplicable_a_pagar_o_valor_de_cupóndescuento_moneda_local;
        private string AI_3907_Cantidad_aplicable_a_pagar_o_valor_de_cupóndescuento_moneda_local;
        private string AI_3908_Cantidad_aplicable_a_pagar_o_valor_de_cupóndescuento_moneda_local;
        private string AI_3909_Cantidad_aplicable_a_pagar_o_valor_de_cupóndescuento_moneda_local;
        private string AI_3910_Cantidad_aplicable_a_pagar_con_código_de_moneda_ISO;
        private string AI_3911_Cantidad_aplicable_a_pagar_con_código_de_moneda_ISO;
        private string AI_3912_Cantidad_aplicable_a_pagar_con_código_de_moneda_ISO;
        private string AI_3913_Cantidad_aplicable_a_pagar_con_código_de_moneda_ISO;
        private string AI_3914_Cantidad_aplicable_a_pagar_con_código_de_moneda_ISO;
        private string AI_3915_Cantidad_aplicable_a_pagar_con_código_de_moneda_ISO;
        private string AI_3916_Cantidad_aplicable_a_pagar_con_código_de_moneda_ISO;
        private string AI_3917_Cantidad_aplicable_a_pagar_con_código_de_moneda_ISO;
        private string AI_3918_Cantidad_aplicable_a_pagar_con_código_de_moneda_ISO;
        private string AI_3919_Cantidad_aplicable_a_pagar_con_código_de_moneda_ISO;
        private string AI_3920_Importe_aplicable_a_pagar_zona_monetaria_única__artículo_comercial_de_medida_variable_;
        private string AI_3921_Importe_aplicable_a_pagar_zona_monetaria_única__artículo_comercial_de_medida_variable_;
        private string AI_3922_Importe_aplicable_a_pagar_zona_monetaria_única__artículo_comercial_de_medida_variable_;
        private string AI_3923_Importe_aplicable_a_pagar_zona_monetaria_única__artículo_comercial_de_medida_variable_;
        private string AI_3924_Importe_aplicable_a_pagar_zona_monetaria_única__artículo_comercial_de_medida_variable_;
        private string AI_3925_Importe_aplicable_a_pagar_zona_monetaria_única__artículo_comercial_de_medida_variable_;
        private string AI_3926_Importe_aplicable_a_pagar_zona_monetaria_única__artículo_comercial_de_medida_variable_;
        private string AI_3927_Importe_aplicable_a_pagar_zona_monetaria_única__artículo_comercial_de_medida_variable_;
        private string AI_3928_Importe_aplicable_a_pagar_zona_monetaria_única__artículo_comercial_de_medida_variable_;
        private string AI_3929_Importe_aplicable_a_pagar_zona_monetaria_única__artículo_comercial_de_medida_variable_;
        private string AI_3930_Importe_aplicable_a_pagar_con_código_de_moneda_ISO__artículo_comercial_de_medida_variable_;
        private string AI_3931_Importe_aplicable_a_pagar_con_código_de_moneda_ISO__artículo_comercial_de_medida_variable_;
        private string AI_3932_Importe_aplicable_a_pagar_con_código_de_moneda_ISO__artículo_comercial_de_medida_variable_;
        private string AI_3933_Importe_aplicable_a_pagar_con_código_de_moneda_ISO__artículo_comercial_de_medida_variable_;
        private string AI_3934_Importe_aplicable_a_pagar_con_código_de_moneda_ISO__artículo_comercial_de_medida_variable_;
        private string AI_3935_Importe_aplicable_a_pagar_con_código_de_moneda_ISO__artículo_comercial_de_medida_variable_;
        private string AI_3936_Importe_aplicable_a_pagar_con_código_de_moneda_ISO__artículo_comercial_de_medida_variable_;
        private string AI_3937_Importe_aplicable_a_pagar_con_código_de_moneda_ISO__artículo_comercial_de_medida_variable_;
        private string AI_3938_Importe_aplicable_a_pagar_con_código_de_moneda_ISO__artículo_comercial_de_medida_variable_;
        private string AI_3939_Importe_aplicable_a_pagar_con_código_de_moneda_ISO__artículo_comercial_de_medida_variable_;
        private string AI_3940_Porcentaje_de_descuento_de_un_cupón;
        private string AI_3941_Porcentaje_de_descuento_de_un_cupón;
        private string AI_3942_Porcentaje_de_descuento_de_un_cupón;
        private string AI_3943_Porcentaje_de_descuento_de_un_cupón;
        private string AI_400__Número_de_orden_de_compra_del_cliente;
        private string AI_401__Número_de_Identificación_Global_para_Consignación__GINC_;
        private string AI_402__Número_de_Identificación_Global_de_Envío__GSIN_;
        private string AI_403__Código_de_enrutamiento;
        private string AI_410__Enviar_a__Enviar_a_Número_Global_de_Localización;
        private string AI_411__Cobrar_a__Facturar_a_Número_Global_de_Localización;
        private string AI_412__Comprado_de_Número_Global_de_Localización;
        private string AI_413__Enviar_para__Entregar__Reenviar_a_Número_Global_de_Localización;
        private string AI_414__Identificación_de_un_lugar_físico__Número_de_Localización_Global;
        private string AI_415__Número_Global_de_Localización_del_emisor_de_la_factura;
        private string AI_416__GLN_del_lugar_de_producción_o_servicio;
        private string AI_417__GLN_de_la_empresa;
        private string AI_420__Enviar_a__Enviar_a_código_postal_dentro_de_una_única_autoridad_postal;
        private string AI_421__Enviar_a__Enviar_a_código_postal_con_código_de_país_ISO;
        private string AI_422__País_de_origen_de_un_artículo_comercial;
        private string AI_423__País_de_procesamiento_inicial;
        private string AI_424__País_de_procesamiento;
        private string AI_425__País_de_desmontaje;
        private string AI_426__País_cubriendo_cadena_de_proceso_completa;
        private string AI_427__Subdivisión_de_país_de_origen;
        private string AI_7001_OTAN_Número_de_stock__NSN_;
        private string AI_7002_ONU__ECE_clasificación_de_canales_y_cortes_de_carne;
        private string AI_7003_Fecha_y_hora_de_caducidad;
        private string AI_7004_Potencia_activa;
        private string AI_7005_Zona_de_captura;
        private string AI_7006_Primera_fecha_de_congelación;
        private string AI_7007_Fecha_de_cosecha;
        private string AI_7008_Especies_con_fines_pesqueros;
        private string AI_7009_Tipo_de_equipo_de_Pesca;
        private string AI_7010_Método_de_producción;
        private string AI_7020_ID_de_lote_remodelación;
        private string AI_7021_Estado_funcional;
        private string AI_7022_Estado_de_revisión;
        private string AI_7023_Identificador_Global_de_un_Bien_Individual__GIAI__de_un_ensamblado;
        private string AI_7030_Número_de_procesador_con_código_de_país_ISO;
        private string AI_7031_Número_de_procesador_con_código_de_país_ISO;
        private string AI_7032_Número_de_procesador_con_código_de_país_ISO;
        private string AI_7033_Número_de_procesador_con_código_de_país_ISO;
        private string AI_7034_Número_de_procesador_con_código_de_país_ISO;
        private string AI_7035_Número_de_procesador_con_código_de_país_ISO;
        private string AI_7036_Número_de_procesador_con_código_de_país_ISO;
        private string AI_7037_Número_de_procesador_con_código_de_país_ISO;
        private string AI_7038_Número_de_procesador_con_código_de_país_ISO;
        private string AI_7039_Número_de_procesador_con_código_de_país_ISO;
        private string AI_7040_GS1_UIC_con_extensión_1_e_índice_de_Importador;
        private string AI_710__Número_nacional_de_reembolso_en_Salud__NHRN___PZN_Alemania;
        private string AI_711__Número_nacional_de_reembolso_en_Salud__NHRN___CIP_Francia;
        private string AI_712__Número_nacional_de_reembolso_en_Salud__NHRN___CN_España;
        private string AI_713__Número_nacional_de_reembolso_en_Salud__NHRN___DRN_Brasil;
        private string AI_714__Número_nacional_de_reembolso_en_Salud__NHRN___AIM_Portugal;
        private string AI_7230_Referencia_para_la_certificación;
        private string AI_7231_Referencia_para_la_certificación;
        private string AI_7232_Referencia_para_la_certificación;
        private string AI_7233_Referencia_para_la_certificación;
        private string AI_7234_Referencia_para_la_certificación;
        private string AI_7235_Referencia_para_la_certificación;
        private string AI_7236_Referencia_para_la_certificación;
        private string AI_7237_Referencia_para_la_certificación;
        private string AI_7238_Referencia_para_la_certificación;
        private string AI_7239_Referencia_para_la_certificación;
        private string AI_7240_ID_de_protocolo;
        private string AI_8001_Número_nacional_de_reembolso_en_Salud__NHRN___NHRN_País_A;
        private string AI_8002_Identificador_de_telefonía_móvil_celular;
        private string AI_8003_Identificador_Global_de_Bien_Retornable__GRAI_;
        private string AI_8004_Identificador_Global_de_Bien_Individual__GIAI_;
        private string AI_8005_Precio_por_unidad_de_medida;
        private string AI_8006_Identification_of_an_individual_trade_item_piece;
        private string AI_8007_Número_de_cuenta_bancaria_internacional__IBAN_;
        private string AI_8008_Fecha_y_hora_de_la_producción;
        private string AI_8009_Indicador_del_sensor_ópticamente_legible;
        private string AI_8010_Identificador_de_componente__parte__CPID_;
        private string AI_8011_Número_de_serie_de_identificador_de_componente__parte_de__CPID_DE_SERIE_;
        private string AI_8012_Versión_del_software;
        private string AI_8013_Número_Global_de_Modelo__GMN_;
        private string AI_8017_Número_de_Relación_de_Servicio_Global_para_identificar_la_relación_entre_una_organización_que_ofrece_servicios_y_el_proveedor_de_los_servicios;
        private string AI_8018_Número_de_Relación_de_Servicio_Global_para_identificar_la_relación_entre_una_organización_que_ofrece_servicios_y_el_receptor_de_los_servicios;
        private string AI_8019_Número_de_instancia_de_relación_de_servicio__SRIN_;
        private string AI_8020_Número_de_referencia_de_comprobante_de_pago;
        private string AI_8026_Identificación_de_las_piezas_de_un_artículo_comercial__ITIP__contenidas_en_una_unidad_logística;
        private string AI_8110_Identificación_de_código_de_cupón_para_uso_en_Norte_América;
        private string AI_8111_Puntos_de_fidelidad_de_un_cupón;
        private string AI_8112_Identificación_de_código_de_cupón_sin_papel_para_uso_en_América_del_Norte;
        private string AI_8200_URL_de_embalaje_extendido;
        private string AI_90___Información_de_mutuo_acuerdo_entre_socios_comerciales;
        private string AI_91___Información_interna_de_compañía;
        private string AI_92___Información_interna_de_compañía;
        private string AI_93___Información_interna_de_compañía;
        private string AI_94___Información_interna_de_compañía;
        private string AI_95___Información_interna_de_compañía;
        private string AI_96___Información_interna_de_compañía;
        private string AI_97___Información_interna_de_compañía;
        private string AI_98___Información_interna_de_compañía;
        private string AI_99___Información_interna_de_compañía;

        public string AI_00___Código_Seriado_de_Contenedor_de_Embarque_SSCC_1
        {
            get
            {
                return AI_00___Código_Seriado_de_Contenedor_de_Embarque_SSCC_;
            }

            set
            {
                AI_00___Código_Seriado_de_Contenedor_de_Embarque_SSCC_ = value;
            }
        }

        public string AI_01___Número_Global_de_Artículo_Comercial_GTIN_1
        {
            get
            {
                return AI_01___Número_Global_de_Artículo_Comercial_GTIN_;
            }

            set
            {
                AI_01___Número_Global_de_Artículo_Comercial_GTIN_ = value;
            }
        }

        public string AI_02___GTIN_de_los_artículos_comerciales_contenidos1
        {
            get
            {
                return AI_02___GTIN_de_los_artículos_comerciales_contenidos;
            }

            set
            {
                AI_02___GTIN_de_los_artículos_comerciales_contenidos = value;
            }
        }

        public string AI_10___Lote_o_número_de_lote1
        {
            get
            {
                return AI_10___Lote_o_número_de_lote;
            }

            set
            {
                AI_10___Lote_o_número_de_lote = value;
            }
        }

        public string AI_11___Fecha_de_producción_AAMMDD_1
        {
            get
            {
                return AI_11___Fecha_de_producción_AAMMDD_;
            }

            set
            {
                AI_11___Fecha_de_producción_AAMMDD_ = value;
            }
        }

        public string AI_12___Fecha_de_vencimiento_de_pago_AAMMDD_1
        {
            get
            {
                return AI_12___Fecha_de_vencimiento_de_pago_AAMMDD_;
            }

            set
            {
                AI_12___Fecha_de_vencimiento_de_pago_AAMMDD_ = value;
            }
        }

        public string AI_13___Fecha_de_envasado_AAMMDD_1
        {
            get
            {
                return AI_13___Fecha_de_envasado_AAMMDD_;
            }

            set
            {
                AI_13___Fecha_de_envasado_AAMMDD_ = value;
            }
        }

        public string AI_15___Fecha_de_consumo_preferente_AAMMDD_1
        {
            get
            {
                return AI_15___Fecha_de_consumo_preferente_AAMMDD_;
            }

            set
            {
                AI_15___Fecha_de_consumo_preferente_AAMMDD_ = value;
            }
        }

        public string AI_16___Última_fecha_de_venta_AAMMDD_1
        {
            get
            {
                return AI_16___Última_fecha_de_venta_AAMMDD_;
            }

            set
            {
                AI_16___Última_fecha_de_venta_AAMMDD_ = value;
            }
        }

        public string AI_17___Fecha_de_vencimiento_AAMMDD_1
        {
            get
            {
                return AI_17___Fecha_de_vencimiento_AAMMDD_;
            }

            set
            {
                AI_17___Fecha_de_vencimiento_AAMMDD_ = value;
            }
        }

        public string AI_20___Variante_de_producto_interno1
        {
            get
            {
                return AI_20___Variante_de_producto_interno;
            }

            set
            {
                AI_20___Variante_de_producto_interno = value;
            }
        }

        public string AI_21___Número_de_serie1
        {
            get
            {
                return AI_21___Número_de_serie;
            }

            set
            {
                AI_21___Número_de_serie = value;
            }
        }

        public string AI_22___Variante_de_producto_de_consumo1
        {
            get
            {
                return AI_22___Variante_de_producto_de_consumo;
            }

            set
            {
                AI_22___Variante_de_producto_de_consumo = value;
            }
        }

        public string AI_235__Extensión_serializada_controlada_de_GTIN_de_terceros_TPX_1
        {
            get
            {
                return AI_235__Extensión_serializada_controlada_de_GTIN_de_terceros_TPX_;
            }

            set
            {
                AI_235__Extensión_serializada_controlada_de_GTIN_de_terceros_TPX_ = value;
            }
        }

        public string AI_240__Identificación_de_producto_adicional_asignado_por_el_fabricante1
        {
            get
            {
                return AI_240__Identificación_de_producto_adicional_asignado_por_el_fabricante;
            }

            set
            {
                AI_240__Identificación_de_producto_adicional_asignado_por_el_fabricante = value;
            }
        }

        public string AI_241__Número_de_pieza_del_cliente1
        {
            get
            {
                return AI_241__Número_de_pieza_del_cliente;
            }

            set
            {
                AI_241__Número_de_pieza_del_cliente = value;
            }
        }

        public string AI_242__Número_de_variación_de_mandado_a_hacer1
        {
            get
            {
                return AI_242__Número_de_variación_de_mandado_a_hacer;
            }

            set
            {
                AI_242__Número_de_variación_de_mandado_a_hacer = value;
            }
        }

        public string AI_243__Número_de_componente_de_empaque1
        {
            get
            {
                return AI_243__Número_de_componente_de_empaque;
            }

            set
            {
                AI_243__Número_de_componente_de_empaque = value;
            }
        }

        public string AI_250__Número_de_serie_secundario1
        {
            get
            {
                return AI_250__Número_de_serie_secundario;
            }

            set
            {
                AI_250__Número_de_serie_secundario = value;
            }
        }

        public string AI_251__Referencia_a_la_entidad_de_origen1
        {
            get
            {
                return AI_251__Referencia_a_la_entidad_de_origen;
            }

            set
            {
                AI_251__Referencia_a_la_entidad_de_origen = value;
            }
        }

        public string AI_253__Identificador_de_tipo_de_documento_global_GDTI_1
        {
            get
            {
                return AI_253__Identificador_de_tipo_de_documento_global_GDTI_;
            }

            set
            {
                AI_253__Identificador_de_tipo_de_documento_global_GDTI_ = value;
            }
        }

        public string AI_254__Componente_de_extensión_del_GLN1
        {
            get
            {
                return AI_254__Componente_de_extensión_del_GLN;
            }

            set
            {
                AI_254__Componente_de_extensión_del_GLN = value;
            }
        }

        public string AI_255__Número_de_cupón_global_GCN_1
        {
            get
            {
                return AI_255__Número_de_cupón_global_GCN_;
            }

            set
            {
                AI_255__Número_de_cupón_global_GCN_ = value;
            }
        }

        public string AI_30___Conteo_variable_de_artículos_artículo_comercial_de_medidas_variables_1
        {
            get
            {
                return AI_30___Conteo_variable_de_artículos_artículo_comercial_de_medidas_variables_;
            }

            set
            {
                AI_30___Conteo_variable_de_artículos_artículo_comercial_de_medidas_variables_ = value;
            }
        }

        public string AI_3100_Peso_neto_kilogramos__artículo_comercial_de_medidas_variables_1
        {
            get
            {
                return AI_3100_Peso_neto_kilogramos__artículo_comercial_de_medidas_variables_;
            }

            set
            {
                AI_3100_Peso_neto_kilogramos__artículo_comercial_de_medidas_variables_ = value;
            }
        }

        public string AI_3101_Peso_neto_kilogramos__artículo_comercial_de_medidas_variables_1
        {
            get
            {
                return AI_3101_Peso_neto_kilogramos__artículo_comercial_de_medidas_variables_;
            }

            set
            {
                AI_3101_Peso_neto_kilogramos__artículo_comercial_de_medidas_variables_ = value;
            }
        }

        public string AI_3102_Peso_neto_kilogramos__artículo_comercial_de_medidas_variables_1
        {
            get
            {
                return AI_3102_Peso_neto_kilogramos__artículo_comercial_de_medidas_variables_;
            }

            set
            {
                AI_3102_Peso_neto_kilogramos__artículo_comercial_de_medidas_variables_ = value;
            }
        }

        public string AI_3103_Peso_neto_kilogramos__artículo_comercial_de_medidas_variables_1
        {
            get
            {
                return AI_3103_Peso_neto_kilogramos__artículo_comercial_de_medidas_variables_;
            }

            set
            {
                AI_3103_Peso_neto_kilogramos__artículo_comercial_de_medidas_variables_ = value;
            }
        }

        public string AI_3104_Peso_neto_kilogramos__artículo_comercial_de_medidas_variables_1
        {
            get
            {
                return AI_3104_Peso_neto_kilogramos__artículo_comercial_de_medidas_variables_;
            }

            set
            {
                AI_3104_Peso_neto_kilogramos__artículo_comercial_de_medidas_variables_ = value;
            }
        }

        public string AI_3105_Peso_neto_kilogramos__artículo_comercial_de_medidas_variables_1
        {
            get
            {
                return AI_3105_Peso_neto_kilogramos__artículo_comercial_de_medidas_variables_;
            }

            set
            {
                AI_3105_Peso_neto_kilogramos__artículo_comercial_de_medidas_variables_ = value;
            }
        }

        public string AI_3110_Longitud_o_primera_dimensión_metros__artículo_comercial_de_medidas_variables_1
        {
            get
            {
                return AI_3110_Longitud_o_primera_dimensión_metros__artículo_comercial_de_medidas_variables_;
            }

            set
            {
                AI_3110_Longitud_o_primera_dimensión_metros__artículo_comercial_de_medidas_variables_ = value;
            }
        }

        public string AI_3111_Longitud_o_primera_dimensión_metros__artículo_comercial_de_medidas_variables_1
        {
            get
            {
                return AI_3111_Longitud_o_primera_dimensión_metros__artículo_comercial_de_medidas_variables_;
            }

            set
            {
                AI_3111_Longitud_o_primera_dimensión_metros__artículo_comercial_de_medidas_variables_ = value;
            }
        }

        public string AI_3112_Longitud_o_primera_dimensión_metros__artículo_comercial_de_medidas_variables_1
        {
            get
            {
                return AI_3112_Longitud_o_primera_dimensión_metros__artículo_comercial_de_medidas_variables_;
            }

            set
            {
                AI_3112_Longitud_o_primera_dimensión_metros__artículo_comercial_de_medidas_variables_ = value;
            }
        }

        public string AI_3113_Longitud_o_primera_dimensión_metros__artículo_comercial_de_medidas_variables_1
        {
            get
            {
                return AI_3113_Longitud_o_primera_dimensión_metros__artículo_comercial_de_medidas_variables_;
            }

            set
            {
                AI_3113_Longitud_o_primera_dimensión_metros__artículo_comercial_de_medidas_variables_ = value;
            }
        }

        public string AI_3114_Longitud_o_primera_dimensión_metros__artículo_comercial_de_medidas_variables_1
        {
            get
            {
                return AI_3114_Longitud_o_primera_dimensión_metros__artículo_comercial_de_medidas_variables_;
            }

            set
            {
                AI_3114_Longitud_o_primera_dimensión_metros__artículo_comercial_de_medidas_variables_ = value;
            }
        }

        public string AI_3115_Longitud_o_primera_dimensión_metros__artículo_comercial_de_medidas_variables_1
        {
            get
            {
                return AI_3115_Longitud_o_primera_dimensión_metros__artículo_comercial_de_medidas_variables_;
            }

            set
            {
                AI_3115_Longitud_o_primera_dimensión_metros__artículo_comercial_de_medidas_variables_ = value;
            }
        }

        public string AI_3120_Ancho_diámetro_o_segunda_dimensión_metros__artículo_comercial_de_medidas_variables_1
        {
            get
            {
                return AI_3120_Ancho_diámetro_o_segunda_dimensión_metros__artículo_comercial_de_medidas_variables_;
            }

            set
            {
                AI_3120_Ancho_diámetro_o_segunda_dimensión_metros__artículo_comercial_de_medidas_variables_ = value;
            }
        }

        public string AI_3121_Ancho_diámetro_o_segunda_dimensión_metros__artículo_comercial_de_medidas_variables_1
        {
            get
            {
                return AI_3121_Ancho_diámetro_o_segunda_dimensión_metros__artículo_comercial_de_medidas_variables_;
            }

            set
            {
                AI_3121_Ancho_diámetro_o_segunda_dimensión_metros__artículo_comercial_de_medidas_variables_ = value;
            }
        }

        public string AI_3122_Ancho_diámetro_o_segunda_dimensión_metros__artículo_comercial_de_medidas_variables_1
        {
            get
            {
                return AI_3122_Ancho_diámetro_o_segunda_dimensión_metros__artículo_comercial_de_medidas_variables_;
            }

            set
            {
                AI_3122_Ancho_diámetro_o_segunda_dimensión_metros__artículo_comercial_de_medidas_variables_ = value;
            }
        }

        public string AI_3123_Ancho_diámetro_o_segunda_dimensión_metros__artículo_comercial_de_medidas_variables_1
        {
            get
            {
                return AI_3123_Ancho_diámetro_o_segunda_dimensión_metros__artículo_comercial_de_medidas_variables_;
            }

            set
            {
                AI_3123_Ancho_diámetro_o_segunda_dimensión_metros__artículo_comercial_de_medidas_variables_ = value;
            }
        }

        public string AI_3124_Ancho_diámetro_o_segunda_dimensión_metros__artículo_comercial_de_medidas_variables_1
        {
            get
            {
                return AI_3124_Ancho_diámetro_o_segunda_dimensión_metros__artículo_comercial_de_medidas_variables_;
            }

            set
            {
                AI_3124_Ancho_diámetro_o_segunda_dimensión_metros__artículo_comercial_de_medidas_variables_ = value;
            }
        }

        public string AI_3125_Ancho_diámetro_o_segunda_dimensión_metros__artículo_comercial_de_medidas_variables_1
        {
            get
            {
                return AI_3125_Ancho_diámetro_o_segunda_dimensión_metros__artículo_comercial_de_medidas_variables_;
            }

            set
            {
                AI_3125_Ancho_diámetro_o_segunda_dimensión_metros__artículo_comercial_de_medidas_variables_ = value;
            }
        }

        public string AI_3130_Profundidad_grosor_altura_o_tercera_dimensión_metros__artículo_comercial_de_medidas_variables_1
        {
            get
            {
                return AI_3130_Profundidad_grosor_altura_o_tercera_dimensión_metros__artículo_comercial_de_medidas_variables_;
            }

            set
            {
                AI_3130_Profundidad_grosor_altura_o_tercera_dimensión_metros__artículo_comercial_de_medidas_variables_ = value;
            }
        }

        public string AI_3131_Profundidad_grosor_altura_o_tercera_dimensión_metros__artículo_comercial_de_medidas_variables_1
        {
            get
            {
                return AI_3131_Profundidad_grosor_altura_o_tercera_dimensión_metros__artículo_comercial_de_medidas_variables_;
            }

            set
            {
                AI_3131_Profundidad_grosor_altura_o_tercera_dimensión_metros__artículo_comercial_de_medidas_variables_ = value;
            }
        }

        public string AI_3132_Profundidad_grosor_altura_o_tercera_dimensión_metros__artículo_comercial_de_medidas_variables_1
        {
            get
            {
                return AI_3132_Profundidad_grosor_altura_o_tercera_dimensión_metros__artículo_comercial_de_medidas_variables_;
            }

            set
            {
                AI_3132_Profundidad_grosor_altura_o_tercera_dimensión_metros__artículo_comercial_de_medidas_variables_ = value;
            }
        }

        public string AI_3133_Profundidad_grosor_altura_o_tercera_dimensión_metros__artículo_comercial_de_medidas_variables_1
        {
            get
            {
                return AI_3133_Profundidad_grosor_altura_o_tercera_dimensión_metros__artículo_comercial_de_medidas_variables_;
            }

            set
            {
                AI_3133_Profundidad_grosor_altura_o_tercera_dimensión_metros__artículo_comercial_de_medidas_variables_ = value;
            }
        }

        public string AI_3134_Profundidad_grosor_altura_o_tercera_dimensión_metros__artículo_comercial_de_medidas_variables_1
        {
            get
            {
                return AI_3134_Profundidad_grosor_altura_o_tercera_dimensión_metros__artículo_comercial_de_medidas_variables_;
            }

            set
            {
                AI_3134_Profundidad_grosor_altura_o_tercera_dimensión_metros__artículo_comercial_de_medidas_variables_ = value;
            }
        }

        public string AI_3135_Profundidad_grosor_altura_o_tercera_dimensión_metros__artículo_comercial_de_medidas_variables_1
        {
            get
            {
                return AI_3135_Profundidad_grosor_altura_o_tercera_dimensión_metros__artículo_comercial_de_medidas_variables_;
            }

            set
            {
                AI_3135_Profundidad_grosor_altura_o_tercera_dimensión_metros__artículo_comercial_de_medidas_variables_ = value;
            }
        }

        public string AI_3140_Área_metros_cuadrados__artículo_comercial_de_medidas_variables_1
        {
            get
            {
                return AI_3140_Área_metros_cuadrados__artículo_comercial_de_medidas_variables_;
            }

            set
            {
                AI_3140_Área_metros_cuadrados__artículo_comercial_de_medidas_variables_ = value;
            }
        }

        public string AI_3141_Área_metros_cuadrados__artículo_comercial_de_medidas_variables_1
        {
            get
            {
                return AI_3141_Área_metros_cuadrados__artículo_comercial_de_medidas_variables_;
            }

            set
            {
                AI_3141_Área_metros_cuadrados__artículo_comercial_de_medidas_variables_ = value;
            }
        }

        public string AI_3142_Área_metros_cuadrados__artículo_comercial_de_medidas_variables_1
        {
            get
            {
                return AI_3142_Área_metros_cuadrados__artículo_comercial_de_medidas_variables_;
            }

            set
            {
                AI_3142_Área_metros_cuadrados__artículo_comercial_de_medidas_variables_ = value;
            }
        }

        public string AI_3143_Área_metros_cuadrados__artículo_comercial_de_medidas_variables_1
        {
            get
            {
                return AI_3143_Área_metros_cuadrados__artículo_comercial_de_medidas_variables_;
            }

            set
            {
                AI_3143_Área_metros_cuadrados__artículo_comercial_de_medidas_variables_ = value;
            }
        }

        public string AI_3144_Área_metros_cuadrados__artículo_comercial_de_medidas_variables_1
        {
            get
            {
                return AI_3144_Área_metros_cuadrados__artículo_comercial_de_medidas_variables_;
            }

            set
            {
                AI_3144_Área_metros_cuadrados__artículo_comercial_de_medidas_variables_ = value;
            }
        }

        public string AI_3145_Área_metros_cuadrados__artículo_comercial_de_medidas_variables_1
        {
            get
            {
                return AI_3145_Área_metros_cuadrados__artículo_comercial_de_medidas_variables_;
            }

            set
            {
                AI_3145_Área_metros_cuadrados__artículo_comercial_de_medidas_variables_ = value;
            }
        }

        public string AI_3150_Volumen_neto_litros__artículo_comercial_de_medidas_variables_1
        {
            get
            {
                return AI_3150_Volumen_neto_litros__artículo_comercial_de_medidas_variables_;
            }

            set
            {
                AI_3150_Volumen_neto_litros__artículo_comercial_de_medidas_variables_ = value;
            }
        }

        public string AI_3151_Volumen_neto_litros__artículo_comercial_de_medidas_variables_1
        {
            get
            {
                return AI_3151_Volumen_neto_litros__artículo_comercial_de_medidas_variables_;
            }

            set
            {
                AI_3151_Volumen_neto_litros__artículo_comercial_de_medidas_variables_ = value;
            }
        }

        public string AI_3152_Volumen_neto_litros__artículo_comercial_de_medidas_variables_1
        {
            get
            {
                return AI_3152_Volumen_neto_litros__artículo_comercial_de_medidas_variables_;
            }

            set
            {
                AI_3152_Volumen_neto_litros__artículo_comercial_de_medidas_variables_ = value;
            }
        }

        public string AI_3153_Volumen_neto_litros__artículo_comercial_de_medidas_variables_1
        {
            get
            {
                return AI_3153_Volumen_neto_litros__artículo_comercial_de_medidas_variables_;
            }

            set
            {
                AI_3153_Volumen_neto_litros__artículo_comercial_de_medidas_variables_ = value;
            }
        }

        public string AI_3154_Volumen_neto_litros__artículo_comercial_de_medidas_variables_1
        {
            get
            {
                return AI_3154_Volumen_neto_litros__artículo_comercial_de_medidas_variables_;
            }

            set
            {
                AI_3154_Volumen_neto_litros__artículo_comercial_de_medidas_variables_ = value;
            }
        }

        public string AI_3155_Volumen_neto_litros__artículo_comercial_de_medidas_variables_1
        {
            get
            {
                return AI_3155_Volumen_neto_litros__artículo_comercial_de_medidas_variables_;
            }

            set
            {
                AI_3155_Volumen_neto_litros__artículo_comercial_de_medidas_variables_ = value;
            }
        }

        public string AI_3160_Volumen_neto_metros_cúbicos__artículo_comercial_de_medidas_variables_1
        {
            get
            {
                return AI_3160_Volumen_neto_metros_cúbicos__artículo_comercial_de_medidas_variables_;
            }

            set
            {
                AI_3160_Volumen_neto_metros_cúbicos__artículo_comercial_de_medidas_variables_ = value;
            }
        }

        public string AI_3161_Volumen_neto_metros_cúbicos__artículo_comercial_de_medidas_variables_1
        {
            get
            {
                return AI_3161_Volumen_neto_metros_cúbicos__artículo_comercial_de_medidas_variables_;
            }

            set
            {
                AI_3161_Volumen_neto_metros_cúbicos__artículo_comercial_de_medidas_variables_ = value;
            }
        }

        public string AI_3162_Volumen_neto_metros_cúbicos__artículo_comercial_de_medidas_variables_1
        {
            get
            {
                return AI_3162_Volumen_neto_metros_cúbicos__artículo_comercial_de_medidas_variables_;
            }

            set
            {
                AI_3162_Volumen_neto_metros_cúbicos__artículo_comercial_de_medidas_variables_ = value;
            }
        }

        public string AI_3163_Volumen_neto_metros_cúbicos__artículo_comercial_de_medidas_variables_1
        {
            get
            {
                return AI_3163_Volumen_neto_metros_cúbicos__artículo_comercial_de_medidas_variables_;
            }

            set
            {
                AI_3163_Volumen_neto_metros_cúbicos__artículo_comercial_de_medidas_variables_ = value;
            }
        }

        public string AI_3164_Volumen_neto_metros_cúbicos__artículo_comercial_de_medidas_variables_1
        {
            get
            {
                return AI_3164_Volumen_neto_metros_cúbicos__artículo_comercial_de_medidas_variables_;
            }

            set
            {
                AI_3164_Volumen_neto_metros_cúbicos__artículo_comercial_de_medidas_variables_ = value;
            }
        }

        public string AI_3165_Volumen_neto_metros_cúbicos__artículo_comercial_de_medidas_variables_1
        {
            get
            {
                return AI_3165_Volumen_neto_metros_cúbicos__artículo_comercial_de_medidas_variables_;
            }

            set
            {
                AI_3165_Volumen_neto_metros_cúbicos__artículo_comercial_de_medidas_variables_ = value;
            }
        }

        public string AI_3200_Peso_neto_libras__artículo_comercial_de_medidas_variables_1
        {
            get
            {
                return AI_3200_Peso_neto_libras__artículo_comercial_de_medidas_variables_;
            }

            set
            {
                AI_3200_Peso_neto_libras__artículo_comercial_de_medidas_variables_ = value;
            }
        }

        public string AI_3201_Peso_neto_libras__artículo_comercial_de_medidas_variables_1
        {
            get
            {
                return AI_3201_Peso_neto_libras__artículo_comercial_de_medidas_variables_;
            }

            set
            {
                AI_3201_Peso_neto_libras__artículo_comercial_de_medidas_variables_ = value;
            }
        }

        public string AI_3202_Peso_neto_libras__artículo_comercial_de_medidas_variables_1
        {
            get
            {
                return AI_3202_Peso_neto_libras__artículo_comercial_de_medidas_variables_;
            }

            set
            {
                AI_3202_Peso_neto_libras__artículo_comercial_de_medidas_variables_ = value;
            }
        }

        public string AI_3203_Peso_neto_libras__artículo_comercial_de_medidas_variables_1
        {
            get
            {
                return AI_3203_Peso_neto_libras__artículo_comercial_de_medidas_variables_;
            }

            set
            {
                AI_3203_Peso_neto_libras__artículo_comercial_de_medidas_variables_ = value;
            }
        }

        public string AI_3204_Peso_neto_libras__artículo_comercial_de_medidas_variables_1
        {
            get
            {
                return AI_3204_Peso_neto_libras__artículo_comercial_de_medidas_variables_;
            }

            set
            {
                AI_3204_Peso_neto_libras__artículo_comercial_de_medidas_variables_ = value;
            }
        }

        public string AI_3205_Peso_neto_libras__artículo_comercial_de_medidas_variables_1
        {
            get
            {
                return AI_3205_Peso_neto_libras__artículo_comercial_de_medidas_variables_;
            }

            set
            {
                AI_3205_Peso_neto_libras__artículo_comercial_de_medidas_variables_ = value;
            }
        }

        public string AI_3210_Longitud_o_primera_dimensión_pulgadas__artículo_comercial_de_medidas_variables_1
        {
            get
            {
                return AI_3210_Longitud_o_primera_dimensión_pulgadas__artículo_comercial_de_medidas_variables_;
            }

            set
            {
                AI_3210_Longitud_o_primera_dimensión_pulgadas__artículo_comercial_de_medidas_variables_ = value;
            }
        }

        public string AI_3211_Longitud_o_primera_dimensión_pulgadas__artículo_comercial_de_medidas_variables_1
        {
            get
            {
                return AI_3211_Longitud_o_primera_dimensión_pulgadas__artículo_comercial_de_medidas_variables_;
            }

            set
            {
                AI_3211_Longitud_o_primera_dimensión_pulgadas__artículo_comercial_de_medidas_variables_ = value;
            }
        }

        public string AI_3212_Longitud_o_primera_dimensión_pulgadas__artículo_comercial_de_medidas_variables_1
        {
            get
            {
                return AI_3212_Longitud_o_primera_dimensión_pulgadas__artículo_comercial_de_medidas_variables_;
            }

            set
            {
                AI_3212_Longitud_o_primera_dimensión_pulgadas__artículo_comercial_de_medidas_variables_ = value;
            }
        }

        public string AI_3213_Longitud_o_primera_dimensión_pulgadas__artículo_comercial_de_medidas_variables_1
        {
            get
            {
                return AI_3213_Longitud_o_primera_dimensión_pulgadas__artículo_comercial_de_medidas_variables_;
            }

            set
            {
                AI_3213_Longitud_o_primera_dimensión_pulgadas__artículo_comercial_de_medidas_variables_ = value;
            }
        }

        public string AI_3214_Longitud_o_primera_dimensión_pulgadas__artículo_comercial_de_medidas_variables_1
        {
            get
            {
                return AI_3214_Longitud_o_primera_dimensión_pulgadas__artículo_comercial_de_medidas_variables_;
            }

            set
            {
                AI_3214_Longitud_o_primera_dimensión_pulgadas__artículo_comercial_de_medidas_variables_ = value;
            }
        }

        public string AI_3215_Longitud_o_primera_dimensión_pulgadas__artículo_comercial_de_medidas_variables_1
        {
            get
            {
                return AI_3215_Longitud_o_primera_dimensión_pulgadas__artículo_comercial_de_medidas_variables_;
            }

            set
            {
                AI_3215_Longitud_o_primera_dimensión_pulgadas__artículo_comercial_de_medidas_variables_ = value;
            }
        }

        public string AI_3220_Longitud_o_primera_dimensión_pies__artículo_comercial_de_medidas_variables_1
        {
            get
            {
                return AI_3220_Longitud_o_primera_dimensión_pies__artículo_comercial_de_medidas_variables_;
            }

            set
            {
                AI_3220_Longitud_o_primera_dimensión_pies__artículo_comercial_de_medidas_variables_ = value;
            }
        }

        public string AI_3221_Longitud_o_primera_dimensión_pies__artículo_comercial_de_medidas_variables_1
        {
            get
            {
                return AI_3221_Longitud_o_primera_dimensión_pies__artículo_comercial_de_medidas_variables_;
            }

            set
            {
                AI_3221_Longitud_o_primera_dimensión_pies__artículo_comercial_de_medidas_variables_ = value;
            }
        }

        public string AI_3222_Longitud_o_primera_dimensión_pies__artículo_comercial_de_medidas_variables_1
        {
            get
            {
                return AI_3222_Longitud_o_primera_dimensión_pies__artículo_comercial_de_medidas_variables_;
            }

            set
            {
                AI_3222_Longitud_o_primera_dimensión_pies__artículo_comercial_de_medidas_variables_ = value;
            }
        }

        public string AI_3223_Longitud_o_primera_dimensión_pies__artículo_comercial_de_medidas_variables_1
        {
            get
            {
                return AI_3223_Longitud_o_primera_dimensión_pies__artículo_comercial_de_medidas_variables_;
            }

            set
            {
                AI_3223_Longitud_o_primera_dimensión_pies__artículo_comercial_de_medidas_variables_ = value;
            }
        }

        public string AI_3224_Longitud_o_primera_dimensión_pies__artículo_comercial_de_medidas_variables_1
        {
            get
            {
                return AI_3224_Longitud_o_primera_dimensión_pies__artículo_comercial_de_medidas_variables_;
            }

            set
            {
                AI_3224_Longitud_o_primera_dimensión_pies__artículo_comercial_de_medidas_variables_ = value;
            }
        }

        public string AI_3225_Longitud_o_primera_dimensión_pies__artículo_comercial_de_medidas_variables_1
        {
            get
            {
                return AI_3225_Longitud_o_primera_dimensión_pies__artículo_comercial_de_medidas_variables_;
            }

            set
            {
                AI_3225_Longitud_o_primera_dimensión_pies__artículo_comercial_de_medidas_variables_ = value;
            }
        }

        public string AI_3230_Longitud_o_primera_dimensión_yardas__artículo_comercial_de_medidas_variables_1
        {
            get
            {
                return AI_3230_Longitud_o_primera_dimensión_yardas__artículo_comercial_de_medidas_variables_;
            }

            set
            {
                AI_3230_Longitud_o_primera_dimensión_yardas__artículo_comercial_de_medidas_variables_ = value;
            }
        }

        public string AI_3231_Longitud_o_primera_dimensión_yardas__artículo_comercial_de_medidas_variables_1
        {
            get
            {
                return AI_3231_Longitud_o_primera_dimensión_yardas__artículo_comercial_de_medidas_variables_;
            }

            set
            {
                AI_3231_Longitud_o_primera_dimensión_yardas__artículo_comercial_de_medidas_variables_ = value;
            }
        }

        public string AI_3232_Longitud_o_primera_dimensión_yardas__artículo_comercial_de_medidas_variables_1
        {
            get
            {
                return AI_3232_Longitud_o_primera_dimensión_yardas__artículo_comercial_de_medidas_variables_;
            }

            set
            {
                AI_3232_Longitud_o_primera_dimensión_yardas__artículo_comercial_de_medidas_variables_ = value;
            }
        }

        public string AI_3233_Longitud_o_primera_dimensión_yardas__artículo_comercial_de_medidas_variables_1
        {
            get
            {
                return AI_3233_Longitud_o_primera_dimensión_yardas__artículo_comercial_de_medidas_variables_;
            }

            set
            {
                AI_3233_Longitud_o_primera_dimensión_yardas__artículo_comercial_de_medidas_variables_ = value;
            }
        }

        public string AI_3234_Longitud_o_primera_dimensión_yardas__artículo_comercial_de_medidas_variables_1
        {
            get
            {
                return AI_3234_Longitud_o_primera_dimensión_yardas__artículo_comercial_de_medidas_variables_;
            }

            set
            {
                AI_3234_Longitud_o_primera_dimensión_yardas__artículo_comercial_de_medidas_variables_ = value;
            }
        }

        public string AI_3235_Longitud_o_primera_dimensión_yardas__artículo_comercial_de_medidas_variables_1
        {
            get
            {
                return AI_3235_Longitud_o_primera_dimensión_yardas__artículo_comercial_de_medidas_variables_;
            }

            set
            {
                AI_3235_Longitud_o_primera_dimensión_yardas__artículo_comercial_de_medidas_variables_ = value;
            }
        }

        public string AI_3240_Ancho_diámetro_o_segunda_dimensión_pulgadas__artículo_comercial_de_medidas_variables_1
        {
            get
            {
                return AI_3240_Ancho_diámetro_o_segunda_dimensión_pulgadas__artículo_comercial_de_medidas_variables_;
            }

            set
            {
                AI_3240_Ancho_diámetro_o_segunda_dimensión_pulgadas__artículo_comercial_de_medidas_variables_ = value;
            }
        }

        public string AI_3241_Ancho_diámetro_o_segunda_dimensión_pulgadas__artículo_comercial_de_medidas_variables_1
        {
            get
            {
                return AI_3241_Ancho_diámetro_o_segunda_dimensión_pulgadas__artículo_comercial_de_medidas_variables_;
            }

            set
            {
                AI_3241_Ancho_diámetro_o_segunda_dimensión_pulgadas__artículo_comercial_de_medidas_variables_ = value;
            }
        }

        public string AI_3242_Ancho_diámetro_o_segunda_dimensión_pulgadas__artículo_comercial_de_medidas_variables_1
        {
            get
            {
                return AI_3242_Ancho_diámetro_o_segunda_dimensión_pulgadas__artículo_comercial_de_medidas_variables_;
            }

            set
            {
                AI_3242_Ancho_diámetro_o_segunda_dimensión_pulgadas__artículo_comercial_de_medidas_variables_ = value;
            }
        }

        public string AI_3243_Ancho_diámetro_o_segunda_dimensión_pulgadas__artículo_comercial_de_medidas_variables_1
        {
            get
            {
                return AI_3243_Ancho_diámetro_o_segunda_dimensión_pulgadas__artículo_comercial_de_medidas_variables_;
            }

            set
            {
                AI_3243_Ancho_diámetro_o_segunda_dimensión_pulgadas__artículo_comercial_de_medidas_variables_ = value;
            }
        }

        public string AI_3244_Ancho_diámetro_o_segunda_dimensión_pulgadas__artículo_comercial_de_medidas_variables_1
        {
            get
            {
                return AI_3244_Ancho_diámetro_o_segunda_dimensión_pulgadas__artículo_comercial_de_medidas_variables_;
            }

            set
            {
                AI_3244_Ancho_diámetro_o_segunda_dimensión_pulgadas__artículo_comercial_de_medidas_variables_ = value;
            }
        }

        public string AI_3245_Ancho_diámetro_o_segunda_dimensión_pulgadas__artículo_comercial_de_medidas_variables_1
        {
            get
            {
                return AI_3245_Ancho_diámetro_o_segunda_dimensión_pulgadas__artículo_comercial_de_medidas_variables_;
            }

            set
            {
                AI_3245_Ancho_diámetro_o_segunda_dimensión_pulgadas__artículo_comercial_de_medidas_variables_ = value;
            }
        }

        public string AI_3250_Ancho_diámetro_o_segunda_dimensión_pies__artículo_comercial_de_medidas_variables_1
        {
            get
            {
                return AI_3250_Ancho_diámetro_o_segunda_dimensión_pies__artículo_comercial_de_medidas_variables_;
            }

            set
            {
                AI_3250_Ancho_diámetro_o_segunda_dimensión_pies__artículo_comercial_de_medidas_variables_ = value;
            }
        }

        public string AI_3251_Ancho_diámetro_o_segunda_dimensión_pies__artículo_comercial_de_medidas_variables_1
        {
            get
            {
                return AI_3251_Ancho_diámetro_o_segunda_dimensión_pies__artículo_comercial_de_medidas_variables_;
            }

            set
            {
                AI_3251_Ancho_diámetro_o_segunda_dimensión_pies__artículo_comercial_de_medidas_variables_ = value;
            }
        }

        public string AI_3252_Ancho_diámetro_o_segunda_dimensión_pies__artículo_comercial_de_medidas_variables_1
        {
            get
            {
                return AI_3252_Ancho_diámetro_o_segunda_dimensión_pies__artículo_comercial_de_medidas_variables_;
            }

            set
            {
                AI_3252_Ancho_diámetro_o_segunda_dimensión_pies__artículo_comercial_de_medidas_variables_ = value;
            }
        }

        public string AI_3253_Ancho_diámetro_o_segunda_dimensión_pies__artículo_comercial_de_medidas_variables_1
        {
            get
            {
                return AI_3253_Ancho_diámetro_o_segunda_dimensión_pies__artículo_comercial_de_medidas_variables_;
            }

            set
            {
                AI_3253_Ancho_diámetro_o_segunda_dimensión_pies__artículo_comercial_de_medidas_variables_ = value;
            }
        }

        public string AI_3254_Ancho_diámetro_o_segunda_dimensión_pies__artículo_comercial_de_medidas_variables_1
        {
            get
            {
                return AI_3254_Ancho_diámetro_o_segunda_dimensión_pies__artículo_comercial_de_medidas_variables_;
            }

            set
            {
                AI_3254_Ancho_diámetro_o_segunda_dimensión_pies__artículo_comercial_de_medidas_variables_ = value;
            }
        }

        public string AI_3255_Ancho_diámetro_o_segunda_dimensión_pies__artículo_comercial_de_medidas_variables_1
        {
            get
            {
                return AI_3255_Ancho_diámetro_o_segunda_dimensión_pies__artículo_comercial_de_medidas_variables_;
            }

            set
            {
                AI_3255_Ancho_diámetro_o_segunda_dimensión_pies__artículo_comercial_de_medidas_variables_ = value;
            }
        }

        public string AI_3260_Ancho_diámetro_o_segunda_dimensión_yardas__artículo_comercial_de_medidas_variables_1
        {
            get
            {
                return AI_3260_Ancho_diámetro_o_segunda_dimensión_yardas__artículo_comercial_de_medidas_variables_;
            }

            set
            {
                AI_3260_Ancho_diámetro_o_segunda_dimensión_yardas__artículo_comercial_de_medidas_variables_ = value;
            }
        }

        public string AI_3261_Ancho_diámetro_o_segunda_dimensión_yardas__artículo_comercial_de_medidas_variables_1
        {
            get
            {
                return AI_3261_Ancho_diámetro_o_segunda_dimensión_yardas__artículo_comercial_de_medidas_variables_;
            }

            set
            {
                AI_3261_Ancho_diámetro_o_segunda_dimensión_yardas__artículo_comercial_de_medidas_variables_ = value;
            }
        }

        public string AI_3262_Ancho_diámetro_o_segunda_dimensión_yardas__artículo_comercial_de_medidas_variables_1
        {
            get
            {
                return AI_3262_Ancho_diámetro_o_segunda_dimensión_yardas__artículo_comercial_de_medidas_variables_;
            }

            set
            {
                AI_3262_Ancho_diámetro_o_segunda_dimensión_yardas__artículo_comercial_de_medidas_variables_ = value;
            }
        }

        public string AI_3263_Ancho_diámetro_o_segunda_dimensión_yardas__artículo_comercial_de_medidas_variables_1
        {
            get
            {
                return AI_3263_Ancho_diámetro_o_segunda_dimensión_yardas__artículo_comercial_de_medidas_variables_;
            }

            set
            {
                AI_3263_Ancho_diámetro_o_segunda_dimensión_yardas__artículo_comercial_de_medidas_variables_ = value;
            }
        }

        public string AI_3264_Ancho_diámetro_o_segunda_dimensión_yardas__artículo_comercial_de_medidas_variables_1
        {
            get
            {
                return AI_3264_Ancho_diámetro_o_segunda_dimensión_yardas__artículo_comercial_de_medidas_variables_;
            }

            set
            {
                AI_3264_Ancho_diámetro_o_segunda_dimensión_yardas__artículo_comercial_de_medidas_variables_ = value;
            }
        }

        public string AI_3265_Ancho_diámetro_o_segunda_dimensión_yardas__artículo_comercial_de_medidas_variables_1
        {
            get
            {
                return AI_3265_Ancho_diámetro_o_segunda_dimensión_yardas__artículo_comercial_de_medidas_variables_;
            }

            set
            {
                AI_3265_Ancho_diámetro_o_segunda_dimensión_yardas__artículo_comercial_de_medidas_variables_ = value;
            }
        }

        public string AI_3270_Profundidad_grosor_altura_o_tercera_dimensión_pulgadas__artículo_comercial_de_medidas_variables_1
        {
            get
            {
                return AI_3270_Profundidad_grosor_altura_o_tercera_dimensión_pulgadas__artículo_comercial_de_medidas_variables_;
            }

            set
            {
                AI_3270_Profundidad_grosor_altura_o_tercera_dimensión_pulgadas__artículo_comercial_de_medidas_variables_ = value;
            }
        }

        public string AI_3271_Profundidad_grosor_altura_o_tercera_dimensión_pulgadas__artículo_comercial_de_medidas_variables_1
        {
            get
            {
                return AI_3271_Profundidad_grosor_altura_o_tercera_dimensión_pulgadas__artículo_comercial_de_medidas_variables_;
            }

            set
            {
                AI_3271_Profundidad_grosor_altura_o_tercera_dimensión_pulgadas__artículo_comercial_de_medidas_variables_ = value;
            }
        }

        public string AI_3272_Profundidad_grosor_altura_o_tercera_dimensión_pulgadas__artículo_comercial_de_medidas_variables_1
        {
            get
            {
                return AI_3272_Profundidad_grosor_altura_o_tercera_dimensión_pulgadas__artículo_comercial_de_medidas_variables_;
            }

            set
            {
                AI_3272_Profundidad_grosor_altura_o_tercera_dimensión_pulgadas__artículo_comercial_de_medidas_variables_ = value;
            }
        }

        public string AI_3273_Profundidad_grosor_altura_o_tercera_dimensión_pulgadas__artículo_comercial_de_medidas_variables_1
        {
            get
            {
                return AI_3273_Profundidad_grosor_altura_o_tercera_dimensión_pulgadas__artículo_comercial_de_medidas_variables_;
            }

            set
            {
                AI_3273_Profundidad_grosor_altura_o_tercera_dimensión_pulgadas__artículo_comercial_de_medidas_variables_ = value;
            }
        }

        public string AI_3274_Profundidad_grosor_altura_o_tercera_dimensión_pulgadas__artículo_comercial_de_medidas_variables_1
        {
            get
            {
                return AI_3274_Profundidad_grosor_altura_o_tercera_dimensión_pulgadas__artículo_comercial_de_medidas_variables_;
            }

            set
            {
                AI_3274_Profundidad_grosor_altura_o_tercera_dimensión_pulgadas__artículo_comercial_de_medidas_variables_ = value;
            }
        }

        public string AI_3275_Profundidad_grosor_altura_o_tercera_dimensión_pulgadas__artículo_comercial_de_medidas_variables_1
        {
            get
            {
                return AI_3275_Profundidad_grosor_altura_o_tercera_dimensión_pulgadas__artículo_comercial_de_medidas_variables_;
            }

            set
            {
                AI_3275_Profundidad_grosor_altura_o_tercera_dimensión_pulgadas__artículo_comercial_de_medidas_variables_ = value;
            }
        }

        public string AI_3280_Profundidad_grosor_altura_o_tercera_dimensión_pies__artículo_comercial_de_medidas_variables_1
        {
            get
            {
                return AI_3280_Profundidad_grosor_altura_o_tercera_dimensión_pies__artículo_comercial_de_medidas_variables_;
            }

            set
            {
                AI_3280_Profundidad_grosor_altura_o_tercera_dimensión_pies__artículo_comercial_de_medidas_variables_ = value;
            }
        }

        public string AI_3281_Profundidad_grosor_altura_o_tercera_dimensión_pies__artículo_comercial_de_medidas_variables_1
        {
            get
            {
                return AI_3281_Profundidad_grosor_altura_o_tercera_dimensión_pies__artículo_comercial_de_medidas_variables_;
            }

            set
            {
                AI_3281_Profundidad_grosor_altura_o_tercera_dimensión_pies__artículo_comercial_de_medidas_variables_ = value;
            }
        }

        public string AI_3282_Profundidad_grosor_altura_o_tercera_dimensión_pies__artículo_comercial_de_medidas_variables_1
        {
            get
            {
                return AI_3282_Profundidad_grosor_altura_o_tercera_dimensión_pies__artículo_comercial_de_medidas_variables_;
            }

            set
            {
                AI_3282_Profundidad_grosor_altura_o_tercera_dimensión_pies__artículo_comercial_de_medidas_variables_ = value;
            }
        }

        public string AI_3283_Profundidad_grosor_altura_o_tercera_dimensión_pies__artículo_comercial_de_medidas_variables_1
        {
            get
            {
                return AI_3283_Profundidad_grosor_altura_o_tercera_dimensión_pies__artículo_comercial_de_medidas_variables_;
            }

            set
            {
                AI_3283_Profundidad_grosor_altura_o_tercera_dimensión_pies__artículo_comercial_de_medidas_variables_ = value;
            }
        }

        public string AI_3284_Profundidad_grosor_altura_o_tercera_dimensión_pies__artículo_comercial_de_medidas_variables_1
        {
            get
            {
                return AI_3284_Profundidad_grosor_altura_o_tercera_dimensión_pies__artículo_comercial_de_medidas_variables_;
            }

            set
            {
                AI_3284_Profundidad_grosor_altura_o_tercera_dimensión_pies__artículo_comercial_de_medidas_variables_ = value;
            }
        }

        public string AI_3285_Profundidad_grosor_altura_o_tercera_dimensión_pies__artículo_comercial_de_medidas_variables_1
        {
            get
            {
                return AI_3285_Profundidad_grosor_altura_o_tercera_dimensión_pies__artículo_comercial_de_medidas_variables_;
            }

            set
            {
                AI_3285_Profundidad_grosor_altura_o_tercera_dimensión_pies__artículo_comercial_de_medidas_variables_ = value;
            }
        }

        public string AI_3290_Profundidad_grosor_altura_o_tercera_dimensión_yardas__artículo_comercial_de_medidas_variables_1
        {
            get
            {
                return AI_3290_Profundidad_grosor_altura_o_tercera_dimensión_yardas__artículo_comercial_de_medidas_variables_;
            }

            set
            {
                AI_3290_Profundidad_grosor_altura_o_tercera_dimensión_yardas__artículo_comercial_de_medidas_variables_ = value;
            }
        }

        public string AI_3291_Profundidad_grosor_altura_o_tercera_dimensión_yardas__artículo_comercial_de_medidas_variables_1
        {
            get
            {
                return AI_3291_Profundidad_grosor_altura_o_tercera_dimensión_yardas__artículo_comercial_de_medidas_variables_;
            }

            set
            {
                AI_3291_Profundidad_grosor_altura_o_tercera_dimensión_yardas__artículo_comercial_de_medidas_variables_ = value;
            }
        }

        public string AI_3292_Profundidad_grosor_altura_o_tercera_dimensión_yardas__artículo_comercial_de_medidas_variables_1
        {
            get
            {
                return AI_3292_Profundidad_grosor_altura_o_tercera_dimensión_yardas__artículo_comercial_de_medidas_variables_;
            }

            set
            {
                AI_3292_Profundidad_grosor_altura_o_tercera_dimensión_yardas__artículo_comercial_de_medidas_variables_ = value;
            }
        }

        public string AI_3293_Profundidad_grosor_altura_o_tercera_dimensión_yardas__artículo_comercial_de_medidas_variables_1
        {
            get
            {
                return AI_3293_Profundidad_grosor_altura_o_tercera_dimensión_yardas__artículo_comercial_de_medidas_variables_;
            }

            set
            {
                AI_3293_Profundidad_grosor_altura_o_tercera_dimensión_yardas__artículo_comercial_de_medidas_variables_ = value;
            }
        }

        public string AI_3294_Profundidad_grosor_altura_o_tercera_dimensión_yardas__artículo_comercial_de_medidas_variables_1
        {
            get
            {
                return AI_3294_Profundidad_grosor_altura_o_tercera_dimensión_yardas__artículo_comercial_de_medidas_variables_;
            }

            set
            {
                AI_3294_Profundidad_grosor_altura_o_tercera_dimensión_yardas__artículo_comercial_de_medidas_variables_ = value;
            }
        }

        public string AI_3295_Profundidad_grosor_altura_o_tercera_dimensión_yardas__artículo_comercial_de_medidas_variables_1
        {
            get
            {
                return AI_3295_Profundidad_grosor_altura_o_tercera_dimensión_yardas__artículo_comercial_de_medidas_variables_;
            }

            set
            {
                AI_3295_Profundidad_grosor_altura_o_tercera_dimensión_yardas__artículo_comercial_de_medidas_variables_ = value;
            }
        }

        public string AI_3300_Peso_logístico_kilogramos1
        {
            get
            {
                return AI_3300_Peso_logístico_kilogramos;
            }

            set
            {
                AI_3300_Peso_logístico_kilogramos = value;
            }
        }

        public string AI_3301_Peso_logístico_kilogramos1
        {
            get
            {
                return AI_3301_Peso_logístico_kilogramos;
            }

            set
            {
                AI_3301_Peso_logístico_kilogramos = value;
            }
        }

        public string AI_3302_Peso_logístico_kilogramos1
        {
            get
            {
                return AI_3302_Peso_logístico_kilogramos;
            }

            set
            {
                AI_3302_Peso_logístico_kilogramos = value;
            }
        }

        public string AI_3303_Peso_logístico_kilogramos1
        {
            get
            {
                return AI_3303_Peso_logístico_kilogramos;
            }

            set
            {
                AI_3303_Peso_logístico_kilogramos = value;
            }
        }

        public string AI_3304_Peso_logístico_kilogramos1
        {
            get
            {
                return AI_3304_Peso_logístico_kilogramos;
            }

            set
            {
                AI_3304_Peso_logístico_kilogramos = value;
            }
        }

        public string AI_3305_Peso_logístico_kilogramos1
        {
            get
            {
                return AI_3305_Peso_logístico_kilogramos;
            }

            set
            {
                AI_3305_Peso_logístico_kilogramos = value;
            }
        }

        public string AI_3310_Longitud_o_primera_dimensión_metros1
        {
            get
            {
                return AI_3310_Longitud_o_primera_dimensión_metros;
            }

            set
            {
                AI_3310_Longitud_o_primera_dimensión_metros = value;
            }
        }

        public string AI_3311_Longitud_o_primera_dimensión_metros1
        {
            get
            {
                return AI_3311_Longitud_o_primera_dimensión_metros;
            }

            set
            {
                AI_3311_Longitud_o_primera_dimensión_metros = value;
            }
        }

        public string AI_3312_Longitud_o_primera_dimensión_metros1
        {
            get
            {
                return AI_3312_Longitud_o_primera_dimensión_metros;
            }

            set
            {
                AI_3312_Longitud_o_primera_dimensión_metros = value;
            }
        }

        public string AI_3313_Longitud_o_primera_dimensión_metros1
        {
            get
            {
                return AI_3313_Longitud_o_primera_dimensión_metros;
            }

            set
            {
                AI_3313_Longitud_o_primera_dimensión_metros = value;
            }
        }

        public string AI_3314_Longitud_o_primera_dimensión_metros1
        {
            get
            {
                return AI_3314_Longitud_o_primera_dimensión_metros;
            }

            set
            {
                AI_3314_Longitud_o_primera_dimensión_metros = value;
            }
        }

        public string AI_3315_Longitud_o_primera_dimensión_metros1
        {
            get
            {
                return AI_3315_Longitud_o_primera_dimensión_metros;
            }

            set
            {
                AI_3315_Longitud_o_primera_dimensión_metros = value;
            }
        }

        public string AI_3320_Ancho_diámetro_o_segunda_dimensión_metros1
        {
            get
            {
                return AI_3320_Ancho_diámetro_o_segunda_dimensión_metros;
            }

            set
            {
                AI_3320_Ancho_diámetro_o_segunda_dimensión_metros = value;
            }
        }

        public string AI_3321_Ancho_diámetro_o_segunda_dimensión_metros1
        {
            get
            {
                return AI_3321_Ancho_diámetro_o_segunda_dimensión_metros;
            }

            set
            {
                AI_3321_Ancho_diámetro_o_segunda_dimensión_metros = value;
            }
        }

        public string AI_3322_Ancho_diámetro_o_segunda_dimensión_metros1
        {
            get
            {
                return AI_3322_Ancho_diámetro_o_segunda_dimensión_metros;
            }

            set
            {
                AI_3322_Ancho_diámetro_o_segunda_dimensión_metros = value;
            }
        }

        public string AI_3323_Ancho_diámetro_o_segunda_dimensión_metros1
        {
            get
            {
                return AI_3323_Ancho_diámetro_o_segunda_dimensión_metros;
            }

            set
            {
                AI_3323_Ancho_diámetro_o_segunda_dimensión_metros = value;
            }
        }

        public string AI_3324_Ancho_diámetro_o_segunda_dimensión_metros1
        {
            get
            {
                return AI_3324_Ancho_diámetro_o_segunda_dimensión_metros;
            }

            set
            {
                AI_3324_Ancho_diámetro_o_segunda_dimensión_metros = value;
            }
        }

        public string AI_3325_Ancho_diámetro_o_segunda_dimensión_metros1
        {
            get
            {
                return AI_3325_Ancho_diámetro_o_segunda_dimensión_metros;
            }

            set
            {
                AI_3325_Ancho_diámetro_o_segunda_dimensión_metros = value;
            }
        }

        public string AI_3330_Profundidad_grosor_altura_o_tercera_dimensión_metros1
        {
            get
            {
                return AI_3330_Profundidad_grosor_altura_o_tercera_dimensión_metros;
            }

            set
            {
                AI_3330_Profundidad_grosor_altura_o_tercera_dimensión_metros = value;
            }
        }

        public string AI_3331_Profundidad_grosor_altura_o_tercera_dimensión_metros1
        {
            get
            {
                return AI_3331_Profundidad_grosor_altura_o_tercera_dimensión_metros;
            }

            set
            {
                AI_3331_Profundidad_grosor_altura_o_tercera_dimensión_metros = value;
            }
        }

        public string AI_3332_Profundidad_grosor_altura_o_tercera_dimensión_metros1
        {
            get
            {
                return AI_3332_Profundidad_grosor_altura_o_tercera_dimensión_metros;
            }

            set
            {
                AI_3332_Profundidad_grosor_altura_o_tercera_dimensión_metros = value;
            }
        }

        public string AI_3333_Profundidad_grosor_altura_o_tercera_dimensión_metros1
        {
            get
            {
                return AI_3333_Profundidad_grosor_altura_o_tercera_dimensión_metros;
            }

            set
            {
                AI_3333_Profundidad_grosor_altura_o_tercera_dimensión_metros = value;
            }
        }

        public string AI_3334_Profundidad_grosor_altura_o_tercera_dimensión_metros1
        {
            get
            {
                return AI_3334_Profundidad_grosor_altura_o_tercera_dimensión_metros;
            }

            set
            {
                AI_3334_Profundidad_grosor_altura_o_tercera_dimensión_metros = value;
            }
        }

        public string AI_3335_Profundidad_grosor_altura_o_tercera_dimensión_metros1
        {
            get
            {
                return AI_3335_Profundidad_grosor_altura_o_tercera_dimensión_metros;
            }

            set
            {
                AI_3335_Profundidad_grosor_altura_o_tercera_dimensión_metros = value;
            }
        }

        public string AI_3340_Área_metros_cuadrados1
        {
            get
            {
                return AI_3340_Área_metros_cuadrados;
            }

            set
            {
                AI_3340_Área_metros_cuadrados = value;
            }
        }

        public string AI_3341_Área_metros_cuadrados1
        {
            get
            {
                return AI_3341_Área_metros_cuadrados;
            }

            set
            {
                AI_3341_Área_metros_cuadrados = value;
            }
        }

        public string AI_3342_Área_metros_cuadrados1
        {
            get
            {
                return AI_3342_Área_metros_cuadrados;
            }

            set
            {
                AI_3342_Área_metros_cuadrados = value;
            }
        }

        public string AI_3343_Área_metros_cuadrados1
        {
            get
            {
                return AI_3343_Área_metros_cuadrados;
            }

            set
            {
                AI_3343_Área_metros_cuadrados = value;
            }
        }

        public string AI_3344_Área_metros_cuadrados1
        {
            get
            {
                return AI_3344_Área_metros_cuadrados;
            }

            set
            {
                AI_3344_Área_metros_cuadrados = value;
            }
        }

        public string AI_3345_Área_metros_cuadrados1
        {
            get
            {
                return AI_3345_Área_metros_cuadrados;
            }

            set
            {
                AI_3345_Área_metros_cuadrados = value;
            }
        }

        public string AI_3350_Volumen_logístico_litros1
        {
            get
            {
                return AI_3350_Volumen_logístico_litros;
            }

            set
            {
                AI_3350_Volumen_logístico_litros = value;
            }
        }

        public string AI_3351_Volumen_logístico_litros1
        {
            get
            {
                return AI_3351_Volumen_logístico_litros;
            }

            set
            {
                AI_3351_Volumen_logístico_litros = value;
            }
        }

        public string AI_3352_Volumen_logístico_litros1
        {
            get
            {
                return AI_3352_Volumen_logístico_litros;
            }

            set
            {
                AI_3352_Volumen_logístico_litros = value;
            }
        }

        public string AI_3353_Volumen_logístico_litros1
        {
            get
            {
                return AI_3353_Volumen_logístico_litros;
            }

            set
            {
                AI_3353_Volumen_logístico_litros = value;
            }
        }

        public string AI_3354_Volumen_logístico_litros1
        {
            get
            {
                return AI_3354_Volumen_logístico_litros;
            }

            set
            {
                AI_3354_Volumen_logístico_litros = value;
            }
        }

        public string AI_3355_Volumen_logístico_litros1
        {
            get
            {
                return AI_3355_Volumen_logístico_litros;
            }

            set
            {
                AI_3355_Volumen_logístico_litros = value;
            }
        }

        public string AI_3360_Volumen_logístico_metros_cúbicos1
        {
            get
            {
                return AI_3360_Volumen_logístico_metros_cúbicos;
            }

            set
            {
                AI_3360_Volumen_logístico_metros_cúbicos = value;
            }
        }

        public string AI_3361_Volumen_logístico_metros_cúbicos1
        {
            get
            {
                return AI_3361_Volumen_logístico_metros_cúbicos;
            }

            set
            {
                AI_3361_Volumen_logístico_metros_cúbicos = value;
            }
        }

        public string AI_3362_Volumen_logístico_metros_cúbicos1
        {
            get
            {
                return AI_3362_Volumen_logístico_metros_cúbicos;
            }

            set
            {
                AI_3362_Volumen_logístico_metros_cúbicos = value;
            }
        }

        public string AI_3363_Volumen_logístico_metros_cúbicos1
        {
            get
            {
                return AI_3363_Volumen_logístico_metros_cúbicos;
            }

            set
            {
                AI_3363_Volumen_logístico_metros_cúbicos = value;
            }
        }

        public string AI_3364_Volumen_logístico_metros_cúbicos1
        {
            get
            {
                return AI_3364_Volumen_logístico_metros_cúbicos;
            }

            set
            {
                AI_3364_Volumen_logístico_metros_cúbicos = value;
            }
        }

        public string AI_3365_Volumen_logístico_metros_cúbicos1
        {
            get
            {
                return AI_3365_Volumen_logístico_metros_cúbicos;
            }

            set
            {
                AI_3365_Volumen_logístico_metros_cúbicos = value;
            }
        }

        public string AI_3370_Kilogramos_por_metro_cuadrado1
        {
            get
            {
                return AI_3370_Kilogramos_por_metro_cuadrado;
            }

            set
            {
                AI_3370_Kilogramos_por_metro_cuadrado = value;
            }
        }

        public string AI_3371_Kilogramos_por_metro_cuadrado1
        {
            get
            {
                return AI_3371_Kilogramos_por_metro_cuadrado;
            }

            set
            {
                AI_3371_Kilogramos_por_metro_cuadrado = value;
            }
        }

        public string AI_3372_Kilogramos_por_metro_cuadrado1
        {
            get
            {
                return AI_3372_Kilogramos_por_metro_cuadrado;
            }

            set
            {
                AI_3372_Kilogramos_por_metro_cuadrado = value;
            }
        }

        public string AI_3373_Kilogramos_por_metro_cuadrado1
        {
            get
            {
                return AI_3373_Kilogramos_por_metro_cuadrado;
            }

            set
            {
                AI_3373_Kilogramos_por_metro_cuadrado = value;
            }
        }

        public string AI_3374_Kilogramos_por_metro_cuadrado1
        {
            get
            {
                return AI_3374_Kilogramos_por_metro_cuadrado;
            }

            set
            {
                AI_3374_Kilogramos_por_metro_cuadrado = value;
            }
        }

        public string AI_3375_Kilogramos_por_metro_cuadrado1
        {
            get
            {
                return AI_3375_Kilogramos_por_metro_cuadrado;
            }

            set
            {
                AI_3375_Kilogramos_por_metro_cuadrado = value;
            }
        }

        public string AI_3400_Peso_logístico_libras1
        {
            get
            {
                return AI_3400_Peso_logístico_libras;
            }

            set
            {
                AI_3400_Peso_logístico_libras = value;
            }
        }

        public string AI_3401_Peso_logístico_libras1
        {
            get
            {
                return AI_3401_Peso_logístico_libras;
            }

            set
            {
                AI_3401_Peso_logístico_libras = value;
            }
        }

        public string AI_3402_Peso_logístico_libras1
        {
            get
            {
                return AI_3402_Peso_logístico_libras;
            }

            set
            {
                AI_3402_Peso_logístico_libras = value;
            }
        }

        public string AI_3403_Peso_logístico_libras1
        {
            get
            {
                return AI_3403_Peso_logístico_libras;
            }

            set
            {
                AI_3403_Peso_logístico_libras = value;
            }
        }

        public string AI_3404_Peso_logístico_libras1
        {
            get
            {
                return AI_3404_Peso_logístico_libras;
            }

            set
            {
                AI_3404_Peso_logístico_libras = value;
            }
        }

        public string AI_3405_Peso_logístico_libras1
        {
            get
            {
                return AI_3405_Peso_logístico_libras;
            }

            set
            {
                AI_3405_Peso_logístico_libras = value;
            }
        }

        public string AI_3410_Longitud_o_primera_dimensión_pulgadas1
        {
            get
            {
                return AI_3410_Longitud_o_primera_dimensión_pulgadas;
            }

            set
            {
                AI_3410_Longitud_o_primera_dimensión_pulgadas = value;
            }
        }

        public string AI_3411_Longitud_o_primera_dimensión_pulgadas1
        {
            get
            {
                return AI_3411_Longitud_o_primera_dimensión_pulgadas;
            }

            set
            {
                AI_3411_Longitud_o_primera_dimensión_pulgadas = value;
            }
        }

        public string AI_3412_Longitud_o_primera_dimensión_pulgadas1
        {
            get
            {
                return AI_3412_Longitud_o_primera_dimensión_pulgadas;
            }

            set
            {
                AI_3412_Longitud_o_primera_dimensión_pulgadas = value;
            }
        }

        public string AI_3413_Longitud_o_primera_dimensión_pulgadas1
        {
            get
            {
                return AI_3413_Longitud_o_primera_dimensión_pulgadas;
            }

            set
            {
                AI_3413_Longitud_o_primera_dimensión_pulgadas = value;
            }
        }

        public string AI_3414_Longitud_o_primera_dimensión_pulgadas1
        {
            get
            {
                return AI_3414_Longitud_o_primera_dimensión_pulgadas;
            }

            set
            {
                AI_3414_Longitud_o_primera_dimensión_pulgadas = value;
            }
        }

        public string AI_3415_Longitud_o_primera_dimensión_pulgadas1
        {
            get
            {
                return AI_3415_Longitud_o_primera_dimensión_pulgadas;
            }

            set
            {
                AI_3415_Longitud_o_primera_dimensión_pulgadas = value;
            }
        }

        public string AI_3420_Longitud_o_primera_dimensión_pies1
        {
            get
            {
                return AI_3420_Longitud_o_primera_dimensión_pies;
            }

            set
            {
                AI_3420_Longitud_o_primera_dimensión_pies = value;
            }
        }

        public string AI_3421_Longitud_o_primera_dimensión_pies1
        {
            get
            {
                return AI_3421_Longitud_o_primera_dimensión_pies;
            }

            set
            {
                AI_3421_Longitud_o_primera_dimensión_pies = value;
            }
        }

        public string AI_3422_Longitud_o_primera_dimensión_pies1
        {
            get
            {
                return AI_3422_Longitud_o_primera_dimensión_pies;
            }

            set
            {
                AI_3422_Longitud_o_primera_dimensión_pies = value;
            }
        }

        public string AI_3423_Longitud_o_primera_dimensión_pies1
        {
            get
            {
                return AI_3423_Longitud_o_primera_dimensión_pies;
            }

            set
            {
                AI_3423_Longitud_o_primera_dimensión_pies = value;
            }
        }

        public string AI_3424_Longitud_o_primera_dimensión_pies1
        {
            get
            {
                return AI_3424_Longitud_o_primera_dimensión_pies;
            }

            set
            {
                AI_3424_Longitud_o_primera_dimensión_pies = value;
            }
        }

        public string AI_3425_Longitud_o_primera_dimensión_pies1
        {
            get
            {
                return AI_3425_Longitud_o_primera_dimensión_pies;
            }

            set
            {
                AI_3425_Longitud_o_primera_dimensión_pies = value;
            }
        }

        public string AI_3430_Longitud_o_primera_dimensión_yardas1
        {
            get
            {
                return AI_3430_Longitud_o_primera_dimensión_yardas;
            }

            set
            {
                AI_3430_Longitud_o_primera_dimensión_yardas = value;
            }
        }

        public string AI_3431_Longitud_o_primera_dimensión_yardas1
        {
            get
            {
                return AI_3431_Longitud_o_primera_dimensión_yardas;
            }

            set
            {
                AI_3431_Longitud_o_primera_dimensión_yardas = value;
            }
        }

        public string AI_3432_Longitud_o_primera_dimensión_yardas1
        {
            get
            {
                return AI_3432_Longitud_o_primera_dimensión_yardas;
            }

            set
            {
                AI_3432_Longitud_o_primera_dimensión_yardas = value;
            }
        }

        public string AI_3433_Longitud_o_primera_dimensión_yardas1
        {
            get
            {
                return AI_3433_Longitud_o_primera_dimensión_yardas;
            }

            set
            {
                AI_3433_Longitud_o_primera_dimensión_yardas = value;
            }
        }

        public string AI_3434_Longitud_o_primera_dimensión_yardas1
        {
            get
            {
                return AI_3434_Longitud_o_primera_dimensión_yardas;
            }

            set
            {
                AI_3434_Longitud_o_primera_dimensión_yardas = value;
            }
        }

        public string AI_3435_Longitud_o_primera_dimensión_yardas1
        {
            get
            {
                return AI_3435_Longitud_o_primera_dimensión_yardas;
            }

            set
            {
                AI_3435_Longitud_o_primera_dimensión_yardas = value;
            }
        }

        public string AI_3440_Ancho_diámetro_o_segunda_dimensión_pulgadas1
        {
            get
            {
                return AI_3440_Ancho_diámetro_o_segunda_dimensión_pulgadas;
            }

            set
            {
                AI_3440_Ancho_diámetro_o_segunda_dimensión_pulgadas = value;
            }
        }

        public string AI_3441_Ancho_diámetro_o_segunda_dimensión_pulgadas1
        {
            get
            {
                return AI_3441_Ancho_diámetro_o_segunda_dimensión_pulgadas;
            }

            set
            {
                AI_3441_Ancho_diámetro_o_segunda_dimensión_pulgadas = value;
            }
        }

        public string AI_3442_Ancho_diámetro_o_segunda_dimensión_pulgadas1
        {
            get
            {
                return AI_3442_Ancho_diámetro_o_segunda_dimensión_pulgadas;
            }

            set
            {
                AI_3442_Ancho_diámetro_o_segunda_dimensión_pulgadas = value;
            }
        }

        public string AI_3443_Ancho_diámetro_o_segunda_dimensión_pulgadas1
        {
            get
            {
                return AI_3443_Ancho_diámetro_o_segunda_dimensión_pulgadas;
            }

            set
            {
                AI_3443_Ancho_diámetro_o_segunda_dimensión_pulgadas = value;
            }
        }

        public string AI_3444_Ancho_diámetro_o_segunda_dimensión_pulgadas1
        {
            get
            {
                return AI_3444_Ancho_diámetro_o_segunda_dimensión_pulgadas;
            }

            set
            {
                AI_3444_Ancho_diámetro_o_segunda_dimensión_pulgadas = value;
            }
        }

        public string AI_3445_Ancho_diámetro_o_segunda_dimensión_pulgadas1
        {
            get
            {
                return AI_3445_Ancho_diámetro_o_segunda_dimensión_pulgadas;
            }

            set
            {
                AI_3445_Ancho_diámetro_o_segunda_dimensión_pulgadas = value;
            }
        }

        public string AI_3450_Ancho_diámetro_o_segunda_dimensión_pies1
        {
            get
            {
                return AI_3450_Ancho_diámetro_o_segunda_dimensión_pies;
            }

            set
            {
                AI_3450_Ancho_diámetro_o_segunda_dimensión_pies = value;
            }
        }

        public string AI_3452_Ancho_diámetro_o_segunda_dimensión_pies1
        {
            get
            {
                return AI_3452_Ancho_diámetro_o_segunda_dimensión_pies;
            }

            set
            {
                AI_3452_Ancho_diámetro_o_segunda_dimensión_pies = value;
            }
        }

        public string AI_3451_Ancho_diámetro_o_segunda_dimensión_pies1
        {
            get
            {
                return AI_3451_Ancho_diámetro_o_segunda_dimensión_pies;
            }

            set
            {
                AI_3451_Ancho_diámetro_o_segunda_dimensión_pies = value;
            }
        }

        public string AI_3453_Ancho_diámetro_o_segunda_dimensión_pies1
        {
            get
            {
                return AI_3453_Ancho_diámetro_o_segunda_dimensión_pies;
            }

            set
            {
                AI_3453_Ancho_diámetro_o_segunda_dimensión_pies = value;
            }
        }

        public string AI_3454_Ancho_diámetro_o_segunda_dimensión_pies1
        {
            get
            {
                return AI_3454_Ancho_diámetro_o_segunda_dimensión_pies;
            }

            set
            {
                AI_3454_Ancho_diámetro_o_segunda_dimensión_pies = value;
            }
        }

        public string AI_3455_Ancho_diámetro_o_segunda_dimensión_pies1
        {
            get
            {
                return AI_3455_Ancho_diámetro_o_segunda_dimensión_pies;
            }

            set
            {
                AI_3455_Ancho_diámetro_o_segunda_dimensión_pies = value;
            }
        }

        public string AI_3460_Ancho_diámetro_o_segunda_dimensión_yardas1
        {
            get
            {
                return AI_3460_Ancho_diámetro_o_segunda_dimensión_yardas;
            }

            set
            {
                AI_3460_Ancho_diámetro_o_segunda_dimensión_yardas = value;
            }
        }

        public string AI_3461_Ancho_diámetro_o_segunda_dimensión_yardas1
        {
            get
            {
                return AI_3461_Ancho_diámetro_o_segunda_dimensión_yardas;
            }

            set
            {
                AI_3461_Ancho_diámetro_o_segunda_dimensión_yardas = value;
            }
        }

        public string AI_3462_Ancho_diámetro_o_segunda_dimensión_yardas1
        {
            get
            {
                return AI_3462_Ancho_diámetro_o_segunda_dimensión_yardas;
            }

            set
            {
                AI_3462_Ancho_diámetro_o_segunda_dimensión_yardas = value;
            }
        }

        public string AI_3463_Ancho_diámetro_o_segunda_dimensión_yardas1
        {
            get
            {
                return AI_3463_Ancho_diámetro_o_segunda_dimensión_yardas;
            }

            set
            {
                AI_3463_Ancho_diámetro_o_segunda_dimensión_yardas = value;
            }
        }

        public string AI_3464_Ancho_diámetro_o_segunda_dimensión_yardas1
        {
            get
            {
                return AI_3464_Ancho_diámetro_o_segunda_dimensión_yardas;
            }

            set
            {
                AI_3464_Ancho_diámetro_o_segunda_dimensión_yardas = value;
            }
        }

        public string AI_3465_Ancho_diámetro_o_segunda_dimensión_yardas1
        {
            get
            {
                return AI_3465_Ancho_diámetro_o_segunda_dimensión_yardas;
            }

            set
            {
                AI_3465_Ancho_diámetro_o_segunda_dimensión_yardas = value;
            }
        }

        public string AI_3470_Profundidad_grosor_altura_o_tercera_dimensión_pulgadas1
        {
            get
            {
                return AI_3470_Profundidad_grosor_altura_o_tercera_dimensión_pulgadas;
            }

            set
            {
                AI_3470_Profundidad_grosor_altura_o_tercera_dimensión_pulgadas = value;
            }
        }

        public string AI_3471_Profundidad_grosor_altura_o_tercera_dimensión_pulgadas1
        {
            get
            {
                return AI_3471_Profundidad_grosor_altura_o_tercera_dimensión_pulgadas;
            }

            set
            {
                AI_3471_Profundidad_grosor_altura_o_tercera_dimensión_pulgadas = value;
            }
        }

        public string AI_3472_Profundidad_grosor_altura_o_tercera_dimensión_pulgadas1
        {
            get
            {
                return AI_3472_Profundidad_grosor_altura_o_tercera_dimensión_pulgadas;
            }

            set
            {
                AI_3472_Profundidad_grosor_altura_o_tercera_dimensión_pulgadas = value;
            }
        }

        public string AI_3473_Profundidad_grosor_altura_o_tercera_dimensión_pulgadas1
        {
            get
            {
                return AI_3473_Profundidad_grosor_altura_o_tercera_dimensión_pulgadas;
            }

            set
            {
                AI_3473_Profundidad_grosor_altura_o_tercera_dimensión_pulgadas = value;
            }
        }

        public string AI_3474_Profundidad_grosor_altura_o_tercera_dimensión_pulgadas1
        {
            get
            {
                return AI_3474_Profundidad_grosor_altura_o_tercera_dimensión_pulgadas;
            }

            set
            {
                AI_3474_Profundidad_grosor_altura_o_tercera_dimensión_pulgadas = value;
            }
        }

        public string AI_3475_Profundidad_grosor_altura_o_tercera_dimensión_pulgadas1
        {
            get
            {
                return AI_3475_Profundidad_grosor_altura_o_tercera_dimensión_pulgadas;
            }

            set
            {
                AI_3475_Profundidad_grosor_altura_o_tercera_dimensión_pulgadas = value;
            }
        }

        public string AI_3480_Profundidad_grosor_altura_o_tercera_dimensión_pies1
        {
            get
            {
                return AI_3480_Profundidad_grosor_altura_o_tercera_dimensión_pies;
            }

            set
            {
                AI_3480_Profundidad_grosor_altura_o_tercera_dimensión_pies = value;
            }
        }

        public string AI_3481_Profundidad_grosor_altura_o_tercera_dimensión_pies1
        {
            get
            {
                return AI_3481_Profundidad_grosor_altura_o_tercera_dimensión_pies;
            }

            set
            {
                AI_3481_Profundidad_grosor_altura_o_tercera_dimensión_pies = value;
            }
        }

        public string AI_3482_Profundidad_grosor_altura_o_tercera_dimensión_pies1
        {
            get
            {
                return AI_3482_Profundidad_grosor_altura_o_tercera_dimensión_pies;
            }

            set
            {
                AI_3482_Profundidad_grosor_altura_o_tercera_dimensión_pies = value;
            }
        }

        public string AI_3483_Profundidad_grosor_altura_o_tercera_dimensión_pies1
        {
            get
            {
                return AI_3483_Profundidad_grosor_altura_o_tercera_dimensión_pies;
            }

            set
            {
                AI_3483_Profundidad_grosor_altura_o_tercera_dimensión_pies = value;
            }
        }

        public string AI_3484_Profundidad_grosor_altura_o_tercera_dimensión_pies1
        {
            get
            {
                return AI_3484_Profundidad_grosor_altura_o_tercera_dimensión_pies;
            }

            set
            {
                AI_3484_Profundidad_grosor_altura_o_tercera_dimensión_pies = value;
            }
        }

        public string AI_3485_Profundidad_grosor_altura_o_tercera_dimensión_pies1
        {
            get
            {
                return AI_3485_Profundidad_grosor_altura_o_tercera_dimensión_pies;
            }

            set
            {
                AI_3485_Profundidad_grosor_altura_o_tercera_dimensión_pies = value;
            }
        }

        public string AI_3490_Profundidad_grosor_altura_o_tercera_dimensión_yardas1
        {
            get
            {
                return AI_3490_Profundidad_grosor_altura_o_tercera_dimensión_yardas;
            }

            set
            {
                AI_3490_Profundidad_grosor_altura_o_tercera_dimensión_yardas = value;
            }
        }

        public string AI_3491_Profundidad_grosor_altura_o_tercera_dimensión_yardas1
        {
            get
            {
                return AI_3491_Profundidad_grosor_altura_o_tercera_dimensión_yardas;
            }

            set
            {
                AI_3491_Profundidad_grosor_altura_o_tercera_dimensión_yardas = value;
            }
        }

        public string AI_3492_Profundidad_grosor_altura_o_tercera_dimensión_yardas1
        {
            get
            {
                return AI_3492_Profundidad_grosor_altura_o_tercera_dimensión_yardas;
            }

            set
            {
                AI_3492_Profundidad_grosor_altura_o_tercera_dimensión_yardas = value;
            }
        }

        public string AI_3493_Profundidad_grosor_altura_o_tercera_dimensión_yardas1
        {
            get
            {
                return AI_3493_Profundidad_grosor_altura_o_tercera_dimensión_yardas;
            }

            set
            {
                AI_3493_Profundidad_grosor_altura_o_tercera_dimensión_yardas = value;
            }
        }

        public string AI_3494_Profundidad_grosor_altura_o_tercera_dimensión_yardas1
        {
            get
            {
                return AI_3494_Profundidad_grosor_altura_o_tercera_dimensión_yardas;
            }

            set
            {
                AI_3494_Profundidad_grosor_altura_o_tercera_dimensión_yardas = value;
            }
        }

        public string AI_3495_Profundidad_grosor_altura_o_tercera_dimensión_yardas1
        {
            get
            {
                return AI_3495_Profundidad_grosor_altura_o_tercera_dimensión_yardas;
            }

            set
            {
                AI_3495_Profundidad_grosor_altura_o_tercera_dimensión_yardas = value;
            }
        }

        public string AI_3500_Área_pulgadas_cuadradas__artículo_comercial_de_medidas_variables_1
        {
            get
            {
                return AI_3500_Área_pulgadas_cuadradas__artículo_comercial_de_medidas_variables_;
            }

            set
            {
                AI_3500_Área_pulgadas_cuadradas__artículo_comercial_de_medidas_variables_ = value;
            }
        }

        public string AI_3501_Área_pulgadas_cuadradas__artículo_comercial_de_medidas_variables_1
        {
            get
            {
                return AI_3501_Área_pulgadas_cuadradas__artículo_comercial_de_medidas_variables_;
            }

            set
            {
                AI_3501_Área_pulgadas_cuadradas__artículo_comercial_de_medidas_variables_ = value;
            }
        }

        public string AI_3502_Área_pulgadas_cuadradas__artículo_comercial_de_medidas_variables_1
        {
            get
            {
                return AI_3502_Área_pulgadas_cuadradas__artículo_comercial_de_medidas_variables_;
            }

            set
            {
                AI_3502_Área_pulgadas_cuadradas__artículo_comercial_de_medidas_variables_ = value;
            }
        }

        public string AI_3503_Área_pulgadas_cuadradas__artículo_comercial_de_medidas_variables_1
        {
            get
            {
                return AI_3503_Área_pulgadas_cuadradas__artículo_comercial_de_medidas_variables_;
            }

            set
            {
                AI_3503_Área_pulgadas_cuadradas__artículo_comercial_de_medidas_variables_ = value;
            }
        }

        public string AI_3504_Área_pulgadas_cuadradas__artículo_comercial_de_medidas_variables_1
        {
            get
            {
                return AI_3504_Área_pulgadas_cuadradas__artículo_comercial_de_medidas_variables_;
            }

            set
            {
                AI_3504_Área_pulgadas_cuadradas__artículo_comercial_de_medidas_variables_ = value;
            }
        }

        public string AI_3505_Área_pulgadas_cuadradas__artículo_comercial_de_medidas_variables_1
        {
            get
            {
                return AI_3505_Área_pulgadas_cuadradas__artículo_comercial_de_medidas_variables_;
            }

            set
            {
                AI_3505_Área_pulgadas_cuadradas__artículo_comercial_de_medidas_variables_ = value;
            }
        }

        public string AI_3510_Área_pies_cuadrados__artículo_comercial_de_medidas_variables_1
        {
            get
            {
                return AI_3510_Área_pies_cuadrados__artículo_comercial_de_medidas_variables_;
            }

            set
            {
                AI_3510_Área_pies_cuadrados__artículo_comercial_de_medidas_variables_ = value;
            }
        }

        public string AI_3511_Área_pies_cuadrados__artículo_comercial_de_medidas_variables_1
        {
            get
            {
                return AI_3511_Área_pies_cuadrados__artículo_comercial_de_medidas_variables_;
            }

            set
            {
                AI_3511_Área_pies_cuadrados__artículo_comercial_de_medidas_variables_ = value;
            }
        }

        public string AI_3512_Área_pies_cuadrados__artículo_comercial_de_medidas_variables_1
        {
            get
            {
                return AI_3512_Área_pies_cuadrados__artículo_comercial_de_medidas_variables_;
            }

            set
            {
                AI_3512_Área_pies_cuadrados__artículo_comercial_de_medidas_variables_ = value;
            }
        }

        public string AI_3513_Área_pies_cuadrados__artículo_comercial_de_medidas_variables_1
        {
            get
            {
                return AI_3513_Área_pies_cuadrados__artículo_comercial_de_medidas_variables_;
            }

            set
            {
                AI_3513_Área_pies_cuadrados__artículo_comercial_de_medidas_variables_ = value;
            }
        }

        public string AI_3514_Área_pies_cuadrados__artículo_comercial_de_medidas_variables_1
        {
            get
            {
                return AI_3514_Área_pies_cuadrados__artículo_comercial_de_medidas_variables_;
            }

            set
            {
                AI_3514_Área_pies_cuadrados__artículo_comercial_de_medidas_variables_ = value;
            }
        }

        public string AI_3515_Área_pies_cuadrados__artículo_comercial_de_medidas_variables_1
        {
            get
            {
                return AI_3515_Área_pies_cuadrados__artículo_comercial_de_medidas_variables_;
            }

            set
            {
                AI_3515_Área_pies_cuadrados__artículo_comercial_de_medidas_variables_ = value;
            }
        }

        public string AI_3520_Área_yardas_cuadradas__artículo_comercial_de_medidas_variables_1
        {
            get
            {
                return AI_3520_Área_yardas_cuadradas__artículo_comercial_de_medidas_variables_;
            }

            set
            {
                AI_3520_Área_yardas_cuadradas__artículo_comercial_de_medidas_variables_ = value;
            }
        }

        public string AI_3521_Área_yardas_cuadradas__artículo_comercial_de_medidas_variables_1
        {
            get
            {
                return AI_3521_Área_yardas_cuadradas__artículo_comercial_de_medidas_variables_;
            }

            set
            {
                AI_3521_Área_yardas_cuadradas__artículo_comercial_de_medidas_variables_ = value;
            }
        }

        public string AI_3522_Área_yardas_cuadradas__artículo_comercial_de_medidas_variables_1
        {
            get
            {
                return AI_3522_Área_yardas_cuadradas__artículo_comercial_de_medidas_variables_;
            }

            set
            {
                AI_3522_Área_yardas_cuadradas__artículo_comercial_de_medidas_variables_ = value;
            }
        }

        public string AI_3523_Área_yardas_cuadradas__artículo_comercial_de_medidas_variables_1
        {
            get
            {
                return AI_3523_Área_yardas_cuadradas__artículo_comercial_de_medidas_variables_;
            }

            set
            {
                AI_3523_Área_yardas_cuadradas__artículo_comercial_de_medidas_variables_ = value;
            }
        }

        public string AI_3524_Área_yardas_cuadradas__artículo_comercial_de_medidas_variables_1
        {
            get
            {
                return AI_3524_Área_yardas_cuadradas__artículo_comercial_de_medidas_variables_;
            }

            set
            {
                AI_3524_Área_yardas_cuadradas__artículo_comercial_de_medidas_variables_ = value;
            }
        }

        public string AI_3525_Área_yardas_cuadradas__artículo_comercial_de_medidas_variables_1
        {
            get
            {
                return AI_3525_Área_yardas_cuadradas__artículo_comercial_de_medidas_variables_;
            }

            set
            {
                AI_3525_Área_yardas_cuadradas__artículo_comercial_de_medidas_variables_ = value;
            }
        }

        public string AI_3530_Área_pulgadas_cuadradas1
        {
            get
            {
                return AI_3530_Área_pulgadas_cuadradas;
            }

            set
            {
                AI_3530_Área_pulgadas_cuadradas = value;
            }
        }

        public string AI_3531_Área_pulgadas_cuadradas1
        {
            get
            {
                return AI_3531_Área_pulgadas_cuadradas;
            }

            set
            {
                AI_3531_Área_pulgadas_cuadradas = value;
            }
        }

        public string AI_3532_Área_pulgadas_cuadradas1
        {
            get
            {
                return AI_3532_Área_pulgadas_cuadradas;
            }

            set
            {
                AI_3532_Área_pulgadas_cuadradas = value;
            }
        }

        public string AI_3533_Área_pulgadas_cuadradas1
        {
            get
            {
                return AI_3533_Área_pulgadas_cuadradas;
            }

            set
            {
                AI_3533_Área_pulgadas_cuadradas = value;
            }
        }

        public string AI_3534_Área_pulgadas_cuadradas1
        {
            get
            {
                return AI_3534_Área_pulgadas_cuadradas;
            }

            set
            {
                AI_3534_Área_pulgadas_cuadradas = value;
            }
        }

        public string AI_3535_Área_pulgadas_cuadradas1
        {
            get
            {
                return AI_3535_Área_pulgadas_cuadradas;
            }

            set
            {
                AI_3535_Área_pulgadas_cuadradas = value;
            }
        }

        public string AI_3540_Área_pies_cuadrados1
        {
            get
            {
                return AI_3540_Área_pies_cuadrados;
            }

            set
            {
                AI_3540_Área_pies_cuadrados = value;
            }
        }

        public string AI_3541_Área_pies_cuadrados1
        {
            get
            {
                return AI_3541_Área_pies_cuadrados;
            }

            set
            {
                AI_3541_Área_pies_cuadrados = value;
            }
        }

        public string AI_3542_Área_pies_cuadrados1
        {
            get
            {
                return AI_3542_Área_pies_cuadrados;
            }

            set
            {
                AI_3542_Área_pies_cuadrados = value;
            }
        }

        public string AI_3543_Área_pies_cuadrados1
        {
            get
            {
                return AI_3543_Área_pies_cuadrados;
            }

            set
            {
                AI_3543_Área_pies_cuadrados = value;
            }
        }

        public string AI_3544_Área_pies_cuadrados1
        {
            get
            {
                return AI_3544_Área_pies_cuadrados;
            }

            set
            {
                AI_3544_Área_pies_cuadrados = value;
            }
        }

        public string AI_3545_Área_pies_cuadrados1
        {
            get
            {
                return AI_3545_Área_pies_cuadrados;
            }

            set
            {
                AI_3545_Área_pies_cuadrados = value;
            }
        }

        public string AI_3550_Área_yardas_cuadradas1
        {
            get
            {
                return AI_3550_Área_yardas_cuadradas;
            }

            set
            {
                AI_3550_Área_yardas_cuadradas = value;
            }
        }

        public string AI_3551_Área_yardas_cuadradas1
        {
            get
            {
                return AI_3551_Área_yardas_cuadradas;
            }

            set
            {
                AI_3551_Área_yardas_cuadradas = value;
            }
        }

        public string AI_3552_Área_yardas_cuadradas1
        {
            get
            {
                return AI_3552_Área_yardas_cuadradas;
            }

            set
            {
                AI_3552_Área_yardas_cuadradas = value;
            }
        }

        public string AI_3553_Área_yardas_cuadradas1
        {
            get
            {
                return AI_3553_Área_yardas_cuadradas;
            }

            set
            {
                AI_3553_Área_yardas_cuadradas = value;
            }
        }

        public string AI_3554_Área_yardas_cuadradas1
        {
            get
            {
                return AI_3554_Área_yardas_cuadradas;
            }

            set
            {
                AI_3554_Área_yardas_cuadradas = value;
            }
        }

        public string AI_3555_Área_yardas_cuadradas1
        {
            get
            {
                return AI_3555_Área_yardas_cuadradas;
            }

            set
            {
                AI_3555_Área_yardas_cuadradas = value;
            }
        }

        public string AI_3560_Peso_neto_onzas_troy__artículo_comercial_de_medidas_variables_1
        {
            get
            {
                return AI_3560_Peso_neto_onzas_troy__artículo_comercial_de_medidas_variables_;
            }

            set
            {
                AI_3560_Peso_neto_onzas_troy__artículo_comercial_de_medidas_variables_ = value;
            }
        }

        public string AI_3561_Peso_neto_onzas_troy__artículo_comercial_de_medidas_variables_1
        {
            get
            {
                return AI_3561_Peso_neto_onzas_troy__artículo_comercial_de_medidas_variables_;
            }

            set
            {
                AI_3561_Peso_neto_onzas_troy__artículo_comercial_de_medidas_variables_ = value;
            }
        }

        public string AI_3562_Peso_neto_onzas_troy__artículo_comercial_de_medidas_variables_1
        {
            get
            {
                return AI_3562_Peso_neto_onzas_troy__artículo_comercial_de_medidas_variables_;
            }

            set
            {
                AI_3562_Peso_neto_onzas_troy__artículo_comercial_de_medidas_variables_ = value;
            }
        }

        public string AI_3563_Peso_neto_onzas_troy__artículo_comercial_de_medidas_variables_1
        {
            get
            {
                return AI_3563_Peso_neto_onzas_troy__artículo_comercial_de_medidas_variables_;
            }

            set
            {
                AI_3563_Peso_neto_onzas_troy__artículo_comercial_de_medidas_variables_ = value;
            }
        }

        public string AI_3564_Peso_neto_onzas_troy__artículo_comercial_de_medidas_variables_1
        {
            get
            {
                return AI_3564_Peso_neto_onzas_troy__artículo_comercial_de_medidas_variables_;
            }

            set
            {
                AI_3564_Peso_neto_onzas_troy__artículo_comercial_de_medidas_variables_ = value;
            }
        }

        public string AI_3565_Peso_neto_onzas_troy__artículo_comercial_de_medidas_variables_1
        {
            get
            {
                return AI_3565_Peso_neto_onzas_troy__artículo_comercial_de_medidas_variables_;
            }

            set
            {
                AI_3565_Peso_neto_onzas_troy__artículo_comercial_de_medidas_variables_ = value;
            }
        }

        public string AI_3570_Peso_neto__o_volumen__onzas__artículo_comercial_de_medidas_variables_1
        {
            get
            {
                return AI_3570_Peso_neto__o_volumen__onzas__artículo_comercial_de_medidas_variables_;
            }

            set
            {
                AI_3570_Peso_neto__o_volumen__onzas__artículo_comercial_de_medidas_variables_ = value;
            }
        }

        public string AI_3571_Peso_neto__o_volumen__onzas__artículo_comercial_de_medidas_variables_1
        {
            get
            {
                return AI_3571_Peso_neto__o_volumen__onzas__artículo_comercial_de_medidas_variables_;
            }

            set
            {
                AI_3571_Peso_neto__o_volumen__onzas__artículo_comercial_de_medidas_variables_ = value;
            }
        }

        public string AI_3572_Peso_neto__o_volumen__onzas__artículo_comercial_de_medidas_variables_1
        {
            get
            {
                return AI_3572_Peso_neto__o_volumen__onzas__artículo_comercial_de_medidas_variables_;
            }

            set
            {
                AI_3572_Peso_neto__o_volumen__onzas__artículo_comercial_de_medidas_variables_ = value;
            }
        }

        public string AI_3573_Peso_neto__o_volumen__onzas__artículo_comercial_de_medidas_variables_1
        {
            get
            {
                return AI_3573_Peso_neto__o_volumen__onzas__artículo_comercial_de_medidas_variables_;
            }

            set
            {
                AI_3573_Peso_neto__o_volumen__onzas__artículo_comercial_de_medidas_variables_ = value;
            }
        }

        public string AI_3574_Peso_neto__o_volumen__onzas__artículo_comercial_de_medidas_variables_1
        {
            get
            {
                return AI_3574_Peso_neto__o_volumen__onzas__artículo_comercial_de_medidas_variables_;
            }

            set
            {
                AI_3574_Peso_neto__o_volumen__onzas__artículo_comercial_de_medidas_variables_ = value;
            }
        }

        public string AI_3575_Peso_neto__o_volumen__onzas__artículo_comercial_de_medidas_variables_1
        {
            get
            {
                return AI_3575_Peso_neto__o_volumen__onzas__artículo_comercial_de_medidas_variables_;
            }

            set
            {
                AI_3575_Peso_neto__o_volumen__onzas__artículo_comercial_de_medidas_variables_ = value;
            }
        }

        public string AI_3600_Volumen_neto_cuartos__artículo_comercial_de_medidas_variables_1
        {
            get
            {
                return AI_3600_Volumen_neto_cuartos__artículo_comercial_de_medidas_variables_;
            }

            set
            {
                AI_3600_Volumen_neto_cuartos__artículo_comercial_de_medidas_variables_ = value;
            }
        }

        public string AI_3601_Volumen_neto_cuartos__artículo_comercial_de_medidas_variables_1
        {
            get
            {
                return AI_3601_Volumen_neto_cuartos__artículo_comercial_de_medidas_variables_;
            }

            set
            {
                AI_3601_Volumen_neto_cuartos__artículo_comercial_de_medidas_variables_ = value;
            }
        }

        public string AI_3602_Volumen_neto_cuartos__artículo_comercial_de_medidas_variables_1
        {
            get
            {
                return AI_3602_Volumen_neto_cuartos__artículo_comercial_de_medidas_variables_;
            }

            set
            {
                AI_3602_Volumen_neto_cuartos__artículo_comercial_de_medidas_variables_ = value;
            }
        }

        public string AI_3603_Volumen_neto_cuartos__artículo_comercial_de_medidas_variables_1
        {
            get
            {
                return AI_3603_Volumen_neto_cuartos__artículo_comercial_de_medidas_variables_;
            }

            set
            {
                AI_3603_Volumen_neto_cuartos__artículo_comercial_de_medidas_variables_ = value;
            }
        }

        public string AI_3604_Volumen_neto_cuartos__artículo_comercial_de_medidas_variables_1
        {
            get
            {
                return AI_3604_Volumen_neto_cuartos__artículo_comercial_de_medidas_variables_;
            }

            set
            {
                AI_3604_Volumen_neto_cuartos__artículo_comercial_de_medidas_variables_ = value;
            }
        }

        public string AI_3605_Volumen_neto_cuartos__artículo_comercial_de_medidas_variables_1
        {
            get
            {
                return AI_3605_Volumen_neto_cuartos__artículo_comercial_de_medidas_variables_;
            }

            set
            {
                AI_3605_Volumen_neto_cuartos__artículo_comercial_de_medidas_variables_ = value;
            }
        }

        public string AI_3610_Volumen_neto_galones_estadounidenses__artículo_comercial_de_medidas_variables_1
        {
            get
            {
                return AI_3610_Volumen_neto_galones_estadounidenses__artículo_comercial_de_medidas_variables_;
            }

            set
            {
                AI_3610_Volumen_neto_galones_estadounidenses__artículo_comercial_de_medidas_variables_ = value;
            }
        }

        public string AI_3611_Volumen_neto_galones_estadounidenses__artículo_comercial_de_medidas_variables_1
        {
            get
            {
                return AI_3611_Volumen_neto_galones_estadounidenses__artículo_comercial_de_medidas_variables_;
            }

            set
            {
                AI_3611_Volumen_neto_galones_estadounidenses__artículo_comercial_de_medidas_variables_ = value;
            }
        }

        public string AI_3612_Volumen_neto_galones_estadounidenses__artículo_comercial_de_medidas_variables_1
        {
            get
            {
                return AI_3612_Volumen_neto_galones_estadounidenses__artículo_comercial_de_medidas_variables_;
            }

            set
            {
                AI_3612_Volumen_neto_galones_estadounidenses__artículo_comercial_de_medidas_variables_ = value;
            }
        }

        public string AI_3613_Volumen_neto_galones_estadounidenses__artículo_comercial_de_medidas_variables_1
        {
            get
            {
                return AI_3613_Volumen_neto_galones_estadounidenses__artículo_comercial_de_medidas_variables_;
            }

            set
            {
                AI_3613_Volumen_neto_galones_estadounidenses__artículo_comercial_de_medidas_variables_ = value;
            }
        }

        public string AI_3614_Volumen_neto_galones_estadounidenses__artículo_comercial_de_medidas_variables_1
        {
            get
            {
                return AI_3614_Volumen_neto_galones_estadounidenses__artículo_comercial_de_medidas_variables_;
            }

            set
            {
                AI_3614_Volumen_neto_galones_estadounidenses__artículo_comercial_de_medidas_variables_ = value;
            }
        }

        public string AI_3615_Volumen_neto_galones_estadounidenses__artículo_comercial_de_medidas_variables_1
        {
            get
            {
                return AI_3615_Volumen_neto_galones_estadounidenses__artículo_comercial_de_medidas_variables_;
            }

            set
            {
                AI_3615_Volumen_neto_galones_estadounidenses__artículo_comercial_de_medidas_variables_ = value;
            }
        }

        public string AI_3620_Volumen_logístico_cuartos1
        {
            get
            {
                return AI_3620_Volumen_logístico_cuartos;
            }

            set
            {
                AI_3620_Volumen_logístico_cuartos = value;
            }
        }

        public string AI_3621_Volumen_logístico_cuartos1
        {
            get
            {
                return AI_3621_Volumen_logístico_cuartos;
            }

            set
            {
                AI_3621_Volumen_logístico_cuartos = value;
            }
        }

        public string AI_3622_Volumen_logístico_cuartos1
        {
            get
            {
                return AI_3622_Volumen_logístico_cuartos;
            }

            set
            {
                AI_3622_Volumen_logístico_cuartos = value;
            }
        }

        public string AI_3623_Volumen_logístico_cuartos1
        {
            get
            {
                return AI_3623_Volumen_logístico_cuartos;
            }

            set
            {
                AI_3623_Volumen_logístico_cuartos = value;
            }
        }

        public string AI_3624_Volumen_logístico_cuartos1
        {
            get
            {
                return AI_3624_Volumen_logístico_cuartos;
            }

            set
            {
                AI_3624_Volumen_logístico_cuartos = value;
            }
        }

        public string AI_3625_Volumen_logístico_cuartos1
        {
            get
            {
                return AI_3625_Volumen_logístico_cuartos;
            }

            set
            {
                AI_3625_Volumen_logístico_cuartos = value;
            }
        }

        public string AI_3630_Volumen_logístico_galones_estadounidenses1
        {
            get
            {
                return AI_3630_Volumen_logístico_galones_estadounidenses;
            }

            set
            {
                AI_3630_Volumen_logístico_galones_estadounidenses = value;
            }
        }

        public string AI_3631_Volumen_logístico_galones_estadounidenses1
        {
            get
            {
                return AI_3631_Volumen_logístico_galones_estadounidenses;
            }

            set
            {
                AI_3631_Volumen_logístico_galones_estadounidenses = value;
            }
        }

        public string AI_3632_Volumen_logístico_galones_estadounidenses1
        {
            get
            {
                return AI_3632_Volumen_logístico_galones_estadounidenses;
            }

            set
            {
                AI_3632_Volumen_logístico_galones_estadounidenses = value;
            }
        }

        public string AI_3633_Volumen_logístico_galones_estadounidenses1
        {
            get
            {
                return AI_3633_Volumen_logístico_galones_estadounidenses;
            }

            set
            {
                AI_3633_Volumen_logístico_galones_estadounidenses = value;
            }
        }

        public string AI_3634_Volumen_logístico_galones_estadounidenses1
        {
            get
            {
                return AI_3634_Volumen_logístico_galones_estadounidenses;
            }

            set
            {
                AI_3634_Volumen_logístico_galones_estadounidenses = value;
            }
        }

        public string AI_3635_Volumen_logístico_galones_estadounidenses1
        {
            get
            {
                return AI_3635_Volumen_logístico_galones_estadounidenses;
            }

            set
            {
                AI_3635_Volumen_logístico_galones_estadounidenses = value;
            }
        }

        public string AI_3640_Volumen_neto_pulgadas_cúbicas__artículo_comercial_de_medidas_variables_1
        {
            get
            {
                return AI_3640_Volumen_neto_pulgadas_cúbicas__artículo_comercial_de_medidas_variables_;
            }

            set
            {
                AI_3640_Volumen_neto_pulgadas_cúbicas__artículo_comercial_de_medidas_variables_ = value;
            }
        }

        public string AI_3641_Volumen_neto_pulgadas_cúbicas__artículo_comercial_de_medidas_variables_1
        {
            get
            {
                return AI_3641_Volumen_neto_pulgadas_cúbicas__artículo_comercial_de_medidas_variables_;
            }

            set
            {
                AI_3641_Volumen_neto_pulgadas_cúbicas__artículo_comercial_de_medidas_variables_ = value;
            }
        }

        public string AI_3642_Volumen_neto_pulgadas_cúbicas__artículo_comercial_de_medidas_variables_1
        {
            get
            {
                return AI_3642_Volumen_neto_pulgadas_cúbicas__artículo_comercial_de_medidas_variables_;
            }

            set
            {
                AI_3642_Volumen_neto_pulgadas_cúbicas__artículo_comercial_de_medidas_variables_ = value;
            }
        }

        public string AI_3643_Volumen_neto_pulgadas_cúbicas__artículo_comercial_de_medidas_variables_1
        {
            get
            {
                return AI_3643_Volumen_neto_pulgadas_cúbicas__artículo_comercial_de_medidas_variables_;
            }

            set
            {
                AI_3643_Volumen_neto_pulgadas_cúbicas__artículo_comercial_de_medidas_variables_ = value;
            }
        }

        public string AI_3644_Volumen_neto_pulgadas_cúbicas__artículo_comercial_de_medidas_variables_1
        {
            get
            {
                return AI_3644_Volumen_neto_pulgadas_cúbicas__artículo_comercial_de_medidas_variables_;
            }

            set
            {
                AI_3644_Volumen_neto_pulgadas_cúbicas__artículo_comercial_de_medidas_variables_ = value;
            }
        }

        public string AI_3645_Volumen_neto_pulgadas_cúbicas__artículo_comercial_de_medidas_variables_1
        {
            get
            {
                return AI_3645_Volumen_neto_pulgadas_cúbicas__artículo_comercial_de_medidas_variables_;
            }

            set
            {
                AI_3645_Volumen_neto_pulgadas_cúbicas__artículo_comercial_de_medidas_variables_ = value;
            }
        }

        public string AI_3650_Volumen_neto_pies_cúbicos__artículo_comercial_de_medidas_variables_1
        {
            get
            {
                return AI_3650_Volumen_neto_pies_cúbicos__artículo_comercial_de_medidas_variables_;
            }

            set
            {
                AI_3650_Volumen_neto_pies_cúbicos__artículo_comercial_de_medidas_variables_ = value;
            }
        }

        public string AI_3651_Volumen_neto_pies_cúbicos__artículo_comercial_de_medidas_variables_1
        {
            get
            {
                return AI_3651_Volumen_neto_pies_cúbicos__artículo_comercial_de_medidas_variables_;
            }

            set
            {
                AI_3651_Volumen_neto_pies_cúbicos__artículo_comercial_de_medidas_variables_ = value;
            }
        }

        public string AI_3652_Volumen_neto_pies_cúbicos__artículo_comercial_de_medidas_variables_1
        {
            get
            {
                return AI_3652_Volumen_neto_pies_cúbicos__artículo_comercial_de_medidas_variables_;
            }

            set
            {
                AI_3652_Volumen_neto_pies_cúbicos__artículo_comercial_de_medidas_variables_ = value;
            }
        }

        public string AI_3653_Volumen_neto_pies_cúbicos__artículo_comercial_de_medidas_variables_1
        {
            get
            {
                return AI_3653_Volumen_neto_pies_cúbicos__artículo_comercial_de_medidas_variables_;
            }

            set
            {
                AI_3653_Volumen_neto_pies_cúbicos__artículo_comercial_de_medidas_variables_ = value;
            }
        }

        public string AI_3654_Volumen_neto_pies_cúbicos__artículo_comercial_de_medidas_variables_1
        {
            get
            {
                return AI_3654_Volumen_neto_pies_cúbicos__artículo_comercial_de_medidas_variables_;
            }

            set
            {
                AI_3654_Volumen_neto_pies_cúbicos__artículo_comercial_de_medidas_variables_ = value;
            }
        }

        public string AI_3655_Volumen_neto_pies_cúbicos__artículo_comercial_de_medidas_variables_1
        {
            get
            {
                return AI_3655_Volumen_neto_pies_cúbicos__artículo_comercial_de_medidas_variables_;
            }

            set
            {
                AI_3655_Volumen_neto_pies_cúbicos__artículo_comercial_de_medidas_variables_ = value;
            }
        }

        public string AI_3660_Volumen_neto_yardas_cúbicas__artículo_comercial_de_medidas_variables_1
        {
            get
            {
                return AI_3660_Volumen_neto_yardas_cúbicas__artículo_comercial_de_medidas_variables_;
            }

            set
            {
                AI_3660_Volumen_neto_yardas_cúbicas__artículo_comercial_de_medidas_variables_ = value;
            }
        }

        public string AI_3661_Volumen_neto_yardas_cúbicas__artículo_comercial_de_medidas_variables_1
        {
            get
            {
                return AI_3661_Volumen_neto_yardas_cúbicas__artículo_comercial_de_medidas_variables_;
            }

            set
            {
                AI_3661_Volumen_neto_yardas_cúbicas__artículo_comercial_de_medidas_variables_ = value;
            }
        }

        public string AI_3662_Volumen_neto_yardas_cúbicas__artículo_comercial_de_medidas_variables_1
        {
            get
            {
                return AI_3662_Volumen_neto_yardas_cúbicas__artículo_comercial_de_medidas_variables_;
            }

            set
            {
                AI_3662_Volumen_neto_yardas_cúbicas__artículo_comercial_de_medidas_variables_ = value;
            }
        }

        public string AI_3663_Volumen_neto_yardas_cúbicas__artículo_comercial_de_medidas_variables_1
        {
            get
            {
                return AI_3663_Volumen_neto_yardas_cúbicas__artículo_comercial_de_medidas_variables_;
            }

            set
            {
                AI_3663_Volumen_neto_yardas_cúbicas__artículo_comercial_de_medidas_variables_ = value;
            }
        }

        public string AI_3664_Volumen_neto_yardas_cúbicas__artículo_comercial_de_medidas_variables_1
        {
            get
            {
                return AI_3664_Volumen_neto_yardas_cúbicas__artículo_comercial_de_medidas_variables_;
            }

            set
            {
                AI_3664_Volumen_neto_yardas_cúbicas__artículo_comercial_de_medidas_variables_ = value;
            }
        }

        public string AI_3665_Volumen_neto_yardas_cúbicas__artículo_comercial_de_medidas_variables_1
        {
            get
            {
                return AI_3665_Volumen_neto_yardas_cúbicas__artículo_comercial_de_medidas_variables_;
            }

            set
            {
                AI_3665_Volumen_neto_yardas_cúbicas__artículo_comercial_de_medidas_variables_ = value;
            }
        }

        public string AI_3670_Volumen_Logistic_pulgadas_cúbicas1
        {
            get
            {
                return AI_3670_Volumen_Logistic_pulgadas_cúbicas;
            }

            set
            {
                AI_3670_Volumen_Logistic_pulgadas_cúbicas = value;
            }
        }

        public string AI_3671_Volumen_Logistic_pulgadas_cúbicas1
        {
            get
            {
                return AI_3671_Volumen_Logistic_pulgadas_cúbicas;
            }

            set
            {
                AI_3671_Volumen_Logistic_pulgadas_cúbicas = value;
            }
        }

        public string AI_3672_Volumen_Logistic_pulgadas_cúbicas1
        {
            get
            {
                return AI_3672_Volumen_Logistic_pulgadas_cúbicas;
            }

            set
            {
                AI_3672_Volumen_Logistic_pulgadas_cúbicas = value;
            }
        }

        public string AI_3673_Volumen_Logistic_pulgadas_cúbicas1
        {
            get
            {
                return AI_3673_Volumen_Logistic_pulgadas_cúbicas;
            }

            set
            {
                AI_3673_Volumen_Logistic_pulgadas_cúbicas = value;
            }
        }

        public string AI_3674_Volumen_Logistic_pulgadas_cúbicas1
        {
            get
            {
                return AI_3674_Volumen_Logistic_pulgadas_cúbicas;
            }

            set
            {
                AI_3674_Volumen_Logistic_pulgadas_cúbicas = value;
            }
        }

        public string AI_3675_Volumen_Logistic_pulgadas_cúbicas1
        {
            get
            {
                return AI_3675_Volumen_Logistic_pulgadas_cúbicas;
            }

            set
            {
                AI_3675_Volumen_Logistic_pulgadas_cúbicas = value;
            }
        }

        public string AI_3680_Volumen_logístico_de_pies_cúbicos1
        {
            get
            {
                return AI_3680_Volumen_logístico_de_pies_cúbicos;
            }

            set
            {
                AI_3680_Volumen_logístico_de_pies_cúbicos = value;
            }
        }

        public string AI_3681_Volumen_logístico_de_pies_cúbicos1
        {
            get
            {
                return AI_3681_Volumen_logístico_de_pies_cúbicos;
            }

            set
            {
                AI_3681_Volumen_logístico_de_pies_cúbicos = value;
            }
        }

        public string AI_3682_Volumen_logístico_de_pies_cúbicos1
        {
            get
            {
                return AI_3682_Volumen_logístico_de_pies_cúbicos;
            }

            set
            {
                AI_3682_Volumen_logístico_de_pies_cúbicos = value;
            }
        }

        public string AI_3683_Volumen_logístico_de_pies_cúbicos1
        {
            get
            {
                return AI_3683_Volumen_logístico_de_pies_cúbicos;
            }

            set
            {
                AI_3683_Volumen_logístico_de_pies_cúbicos = value;
            }
        }

        public string AI_3684_Volumen_logístico_de_pies_cúbicos1
        {
            get
            {
                return AI_3684_Volumen_logístico_de_pies_cúbicos;
            }

            set
            {
                AI_3684_Volumen_logístico_de_pies_cúbicos = value;
            }
        }

        public string AI_3685_Volumen_logístico_de_pies_cúbicos1
        {
            get
            {
                return AI_3685_Volumen_logístico_de_pies_cúbicos;
            }

            set
            {
                AI_3685_Volumen_logístico_de_pies_cúbicos = value;
            }
        }

        public string AI_3690_Volumen_logístico_yardas_cúbicas1
        {
            get
            {
                return AI_3690_Volumen_logístico_yardas_cúbicas;
            }

            set
            {
                AI_3690_Volumen_logístico_yardas_cúbicas = value;
            }
        }

        public string AI_3691_Volumen_logístico_yardas_cúbicas1
        {
            get
            {
                return AI_3691_Volumen_logístico_yardas_cúbicas;
            }

            set
            {
                AI_3691_Volumen_logístico_yardas_cúbicas = value;
            }
        }

        public string AI_3692_Volumen_logístico_yardas_cúbicas1
        {
            get
            {
                return AI_3692_Volumen_logístico_yardas_cúbicas;
            }

            set
            {
                AI_3692_Volumen_logístico_yardas_cúbicas = value;
            }
        }

        public string AI_3693_Volumen_logístico_yardas_cúbicas1
        {
            get
            {
                return AI_3693_Volumen_logístico_yardas_cúbicas;
            }

            set
            {
                AI_3693_Volumen_logístico_yardas_cúbicas = value;
            }
        }

        public string AI_3694_Volumen_logístico_yardas_cúbicas1
        {
            get
            {
                return AI_3694_Volumen_logístico_yardas_cúbicas;
            }

            set
            {
                AI_3694_Volumen_logístico_yardas_cúbicas = value;
            }
        }

        public string AI_3695_Volumen_logístico_yardas_cúbicas1
        {
            get
            {
                return AI_3695_Volumen_logístico_yardas_cúbicas;
            }

            set
            {
                AI_3695_Volumen_logístico_yardas_cúbicas = value;
            }
        }

        public string AI_37___Conteo_de_artículos_comerciales_o_piezas_de_artículos_comerciales_contenidos_en_una_unidad_logística1
        {
            get
            {
                return AI_37___Conteo_de_artículos_comerciales_o_piezas_de_artículos_comerciales_contenidos_en_una_unidad_logística;
            }

            set
            {
                AI_37___Conteo_de_artículos_comerciales_o_piezas_de_artículos_comerciales_contenidos_en_una_unidad_logística = value;
            }
        }

        public string AI_3900_Cantidad_aplicable_a_pagar_o_valor_de_cupóndescuento_moneda_local1
        {
            get
            {
                return AI_3900_Cantidad_aplicable_a_pagar_o_valor_de_cupóndescuento_moneda_local;
            }

            set
            {
                AI_3900_Cantidad_aplicable_a_pagar_o_valor_de_cupóndescuento_moneda_local = value;
            }
        }

        public string AI_3901_Cantidad_aplicable_a_pagar_o_valor_de_cupóndescuento_moneda_local1
        {
            get
            {
                return AI_3901_Cantidad_aplicable_a_pagar_o_valor_de_cupóndescuento_moneda_local;
            }

            set
            {
                AI_3901_Cantidad_aplicable_a_pagar_o_valor_de_cupóndescuento_moneda_local = value;
            }
        }

        public string AI_3902_Cantidad_aplicable_a_pagar_o_valor_de_cupóndescuento_moneda_local1
        {
            get
            {
                return AI_3902_Cantidad_aplicable_a_pagar_o_valor_de_cupóndescuento_moneda_local;
            }

            set
            {
                AI_3902_Cantidad_aplicable_a_pagar_o_valor_de_cupóndescuento_moneda_local = value;
            }
        }

        public string AI_3903_Cantidad_aplicable_a_pagar_o_valor_de_cupóndescuento_moneda_local1
        {
            get
            {
                return AI_3903_Cantidad_aplicable_a_pagar_o_valor_de_cupóndescuento_moneda_local;
            }

            set
            {
                AI_3903_Cantidad_aplicable_a_pagar_o_valor_de_cupóndescuento_moneda_local = value;
            }
        }

        public string AI_3904_Cantidad_aplicable_a_pagar_o_valor_de_cupóndescuento_moneda_local1
        {
            get
            {
                return AI_3904_Cantidad_aplicable_a_pagar_o_valor_de_cupóndescuento_moneda_local;
            }

            set
            {
                AI_3904_Cantidad_aplicable_a_pagar_o_valor_de_cupóndescuento_moneda_local = value;
            }
        }

        public string AI_3905_Cantidad_aplicable_a_pagar_o_valor_de_cupóndescuento_moneda_local1
        {
            get
            {
                return AI_3905_Cantidad_aplicable_a_pagar_o_valor_de_cupóndescuento_moneda_local;
            }

            set
            {
                AI_3905_Cantidad_aplicable_a_pagar_o_valor_de_cupóndescuento_moneda_local = value;
            }
        }

        public string AI_3906_Cantidad_aplicable_a_pagar_o_valor_de_cupóndescuento_moneda_local1
        {
            get
            {
                return AI_3906_Cantidad_aplicable_a_pagar_o_valor_de_cupóndescuento_moneda_local;
            }

            set
            {
                AI_3906_Cantidad_aplicable_a_pagar_o_valor_de_cupóndescuento_moneda_local = value;
            }
        }

        public string AI_3907_Cantidad_aplicable_a_pagar_o_valor_de_cupóndescuento_moneda_local1
        {
            get
            {
                return AI_3907_Cantidad_aplicable_a_pagar_o_valor_de_cupóndescuento_moneda_local;
            }

            set
            {
                AI_3907_Cantidad_aplicable_a_pagar_o_valor_de_cupóndescuento_moneda_local = value;
            }
        }

        public string AI_3908_Cantidad_aplicable_a_pagar_o_valor_de_cupóndescuento_moneda_local1
        {
            get
            {
                return AI_3908_Cantidad_aplicable_a_pagar_o_valor_de_cupóndescuento_moneda_local;
            }

            set
            {
                AI_3908_Cantidad_aplicable_a_pagar_o_valor_de_cupóndescuento_moneda_local = value;
            }
        }

        public string AI_3909_Cantidad_aplicable_a_pagar_o_valor_de_cupóndescuento_moneda_local1
        {
            get
            {
                return AI_3909_Cantidad_aplicable_a_pagar_o_valor_de_cupóndescuento_moneda_local;
            }

            set
            {
                AI_3909_Cantidad_aplicable_a_pagar_o_valor_de_cupóndescuento_moneda_local = value;
            }
        }

        public string AI_3910_Cantidad_aplicable_a_pagar_con_código_de_moneda_ISO1
        {
            get
            {
                return AI_3910_Cantidad_aplicable_a_pagar_con_código_de_moneda_ISO;
            }

            set
            {
                AI_3910_Cantidad_aplicable_a_pagar_con_código_de_moneda_ISO = value;
            }
        }

        public string AI_3911_Cantidad_aplicable_a_pagar_con_código_de_moneda_ISO1
        {
            get
            {
                return AI_3911_Cantidad_aplicable_a_pagar_con_código_de_moneda_ISO;
            }

            set
            {
                AI_3911_Cantidad_aplicable_a_pagar_con_código_de_moneda_ISO = value;
            }
        }

        public string AI_3912_Cantidad_aplicable_a_pagar_con_código_de_moneda_ISO1
        {
            get
            {
                return AI_3912_Cantidad_aplicable_a_pagar_con_código_de_moneda_ISO;
            }

            set
            {
                AI_3912_Cantidad_aplicable_a_pagar_con_código_de_moneda_ISO = value;
            }
        }

        public string AI_3913_Cantidad_aplicable_a_pagar_con_código_de_moneda_ISO1
        {
            get
            {
                return AI_3913_Cantidad_aplicable_a_pagar_con_código_de_moneda_ISO;
            }

            set
            {
                AI_3913_Cantidad_aplicable_a_pagar_con_código_de_moneda_ISO = value;
            }
        }

        public string AI_3914_Cantidad_aplicable_a_pagar_con_código_de_moneda_ISO1
        {
            get
            {
                return AI_3914_Cantidad_aplicable_a_pagar_con_código_de_moneda_ISO;
            }

            set
            {
                AI_3914_Cantidad_aplicable_a_pagar_con_código_de_moneda_ISO = value;
            }
        }

        public string AI_3915_Cantidad_aplicable_a_pagar_con_código_de_moneda_ISO1
        {
            get
            {
                return AI_3915_Cantidad_aplicable_a_pagar_con_código_de_moneda_ISO;
            }

            set
            {
                AI_3915_Cantidad_aplicable_a_pagar_con_código_de_moneda_ISO = value;
            }
        }

        public string AI_3916_Cantidad_aplicable_a_pagar_con_código_de_moneda_ISO1
        {
            get
            {
                return AI_3916_Cantidad_aplicable_a_pagar_con_código_de_moneda_ISO;
            }

            set
            {
                AI_3916_Cantidad_aplicable_a_pagar_con_código_de_moneda_ISO = value;
            }
        }

        public string AI_3917_Cantidad_aplicable_a_pagar_con_código_de_moneda_ISO1
        {
            get
            {
                return AI_3917_Cantidad_aplicable_a_pagar_con_código_de_moneda_ISO;
            }

            set
            {
                AI_3917_Cantidad_aplicable_a_pagar_con_código_de_moneda_ISO = value;
            }
        }

        public string AI_3918_Cantidad_aplicable_a_pagar_con_código_de_moneda_ISO1
        {
            get
            {
                return AI_3918_Cantidad_aplicable_a_pagar_con_código_de_moneda_ISO;
            }

            set
            {
                AI_3918_Cantidad_aplicable_a_pagar_con_código_de_moneda_ISO = value;
            }
        }

        public string AI_3919_Cantidad_aplicable_a_pagar_con_código_de_moneda_ISO1
        {
            get
            {
                return AI_3919_Cantidad_aplicable_a_pagar_con_código_de_moneda_ISO;
            }

            set
            {
                AI_3919_Cantidad_aplicable_a_pagar_con_código_de_moneda_ISO = value;
            }
        }

        public string AI_3920_Importe_aplicable_a_pagar_zona_monetaria_única__artículo_comercial_de_medida_variable_1
        {
            get
            {
                return AI_3920_Importe_aplicable_a_pagar_zona_monetaria_única__artículo_comercial_de_medida_variable_;
            }

            set
            {
                AI_3920_Importe_aplicable_a_pagar_zona_monetaria_única__artículo_comercial_de_medida_variable_ = value;
            }
        }

        public string AI_3921_Importe_aplicable_a_pagar_zona_monetaria_única__artículo_comercial_de_medida_variable_1
        {
            get
            {
                return AI_3921_Importe_aplicable_a_pagar_zona_monetaria_única__artículo_comercial_de_medida_variable_;
            }

            set
            {
                AI_3921_Importe_aplicable_a_pagar_zona_monetaria_única__artículo_comercial_de_medida_variable_ = value;
            }
        }

        public string AI_3922_Importe_aplicable_a_pagar_zona_monetaria_única__artículo_comercial_de_medida_variable_1
        {
            get
            {
                return AI_3922_Importe_aplicable_a_pagar_zona_monetaria_única__artículo_comercial_de_medida_variable_;
            }

            set
            {
                AI_3922_Importe_aplicable_a_pagar_zona_monetaria_única__artículo_comercial_de_medida_variable_ = value;
            }
        }

        public string AI_3923_Importe_aplicable_a_pagar_zona_monetaria_única__artículo_comercial_de_medida_variable_1
        {
            get
            {
                return AI_3923_Importe_aplicable_a_pagar_zona_monetaria_única__artículo_comercial_de_medida_variable_;
            }

            set
            {
                AI_3923_Importe_aplicable_a_pagar_zona_monetaria_única__artículo_comercial_de_medida_variable_ = value;
            }
        }

        public string AI_3924_Importe_aplicable_a_pagar_zona_monetaria_única__artículo_comercial_de_medida_variable_1
        {
            get
            {
                return AI_3924_Importe_aplicable_a_pagar_zona_monetaria_única__artículo_comercial_de_medida_variable_;
            }

            set
            {
                AI_3924_Importe_aplicable_a_pagar_zona_monetaria_única__artículo_comercial_de_medida_variable_ = value;
            }
        }

        public string AI_3925_Importe_aplicable_a_pagar_zona_monetaria_única__artículo_comercial_de_medida_variable_1
        {
            get
            {
                return AI_3925_Importe_aplicable_a_pagar_zona_monetaria_única__artículo_comercial_de_medida_variable_;
            }

            set
            {
                AI_3925_Importe_aplicable_a_pagar_zona_monetaria_única__artículo_comercial_de_medida_variable_ = value;
            }
        }

        public string AI_3926_Importe_aplicable_a_pagar_zona_monetaria_única__artículo_comercial_de_medida_variable_1
        {
            get
            {
                return AI_3926_Importe_aplicable_a_pagar_zona_monetaria_única__artículo_comercial_de_medida_variable_;
            }

            set
            {
                AI_3926_Importe_aplicable_a_pagar_zona_monetaria_única__artículo_comercial_de_medida_variable_ = value;
            }
        }

        public string AI_3927_Importe_aplicable_a_pagar_zona_monetaria_única__artículo_comercial_de_medida_variable_1
        {
            get
            {
                return AI_3927_Importe_aplicable_a_pagar_zona_monetaria_única__artículo_comercial_de_medida_variable_;
            }

            set
            {
                AI_3927_Importe_aplicable_a_pagar_zona_monetaria_única__artículo_comercial_de_medida_variable_ = value;
            }
        }

        public string AI_3928_Importe_aplicable_a_pagar_zona_monetaria_única__artículo_comercial_de_medida_variable_1
        {
            get
            {
                return AI_3928_Importe_aplicable_a_pagar_zona_monetaria_única__artículo_comercial_de_medida_variable_;
            }

            set
            {
                AI_3928_Importe_aplicable_a_pagar_zona_monetaria_única__artículo_comercial_de_medida_variable_ = value;
            }
        }

        public string AI_3929_Importe_aplicable_a_pagar_zona_monetaria_única__artículo_comercial_de_medida_variable_1
        {
            get
            {
                return AI_3929_Importe_aplicable_a_pagar_zona_monetaria_única__artículo_comercial_de_medida_variable_;
            }

            set
            {
                AI_3929_Importe_aplicable_a_pagar_zona_monetaria_única__artículo_comercial_de_medida_variable_ = value;
            }
        }

        public string AI_3930_Importe_aplicable_a_pagar_con_código_de_moneda_ISO__artículo_comercial_de_medida_variable_1
        {
            get
            {
                return AI_3930_Importe_aplicable_a_pagar_con_código_de_moneda_ISO__artículo_comercial_de_medida_variable_;
            }

            set
            {
                AI_3930_Importe_aplicable_a_pagar_con_código_de_moneda_ISO__artículo_comercial_de_medida_variable_ = value;
            }
        }

        public string AI_3931_Importe_aplicable_a_pagar_con_código_de_moneda_ISO__artículo_comercial_de_medida_variable_1
        {
            get
            {
                return AI_3931_Importe_aplicable_a_pagar_con_código_de_moneda_ISO__artículo_comercial_de_medida_variable_;
            }

            set
            {
                AI_3931_Importe_aplicable_a_pagar_con_código_de_moneda_ISO__artículo_comercial_de_medida_variable_ = value;
            }
        }

        public string AI_3932_Importe_aplicable_a_pagar_con_código_de_moneda_ISO__artículo_comercial_de_medida_variable_1
        {
            get
            {
                return AI_3932_Importe_aplicable_a_pagar_con_código_de_moneda_ISO__artículo_comercial_de_medida_variable_;
            }

            set
            {
                AI_3932_Importe_aplicable_a_pagar_con_código_de_moneda_ISO__artículo_comercial_de_medida_variable_ = value;
            }
        }

        public string AI_3933_Importe_aplicable_a_pagar_con_código_de_moneda_ISO__artículo_comercial_de_medida_variable_1
        {
            get
            {
                return AI_3933_Importe_aplicable_a_pagar_con_código_de_moneda_ISO__artículo_comercial_de_medida_variable_;
            }

            set
            {
                AI_3933_Importe_aplicable_a_pagar_con_código_de_moneda_ISO__artículo_comercial_de_medida_variable_ = value;
            }
        }

        public string AI_3934_Importe_aplicable_a_pagar_con_código_de_moneda_ISO__artículo_comercial_de_medida_variable_1
        {
            get
            {
                return AI_3934_Importe_aplicable_a_pagar_con_código_de_moneda_ISO__artículo_comercial_de_medida_variable_;
            }

            set
            {
                AI_3934_Importe_aplicable_a_pagar_con_código_de_moneda_ISO__artículo_comercial_de_medida_variable_ = value;
            }
        }

        public string AI_3935_Importe_aplicable_a_pagar_con_código_de_moneda_ISO__artículo_comercial_de_medida_variable_1
        {
            get
            {
                return AI_3935_Importe_aplicable_a_pagar_con_código_de_moneda_ISO__artículo_comercial_de_medida_variable_;
            }

            set
            {
                AI_3935_Importe_aplicable_a_pagar_con_código_de_moneda_ISO__artículo_comercial_de_medida_variable_ = value;
            }
        }

        public string AI_3936_Importe_aplicable_a_pagar_con_código_de_moneda_ISO__artículo_comercial_de_medida_variable_1
        {
            get
            {
                return AI_3936_Importe_aplicable_a_pagar_con_código_de_moneda_ISO__artículo_comercial_de_medida_variable_;
            }

            set
            {
                AI_3936_Importe_aplicable_a_pagar_con_código_de_moneda_ISO__artículo_comercial_de_medida_variable_ = value;
            }
        }

        public string AI_3937_Importe_aplicable_a_pagar_con_código_de_moneda_ISO__artículo_comercial_de_medida_variable_1
        {
            get
            {
                return AI_3937_Importe_aplicable_a_pagar_con_código_de_moneda_ISO__artículo_comercial_de_medida_variable_;
            }

            set
            {
                AI_3937_Importe_aplicable_a_pagar_con_código_de_moneda_ISO__artículo_comercial_de_medida_variable_ = value;
            }
        }

        public string AI_3938_Importe_aplicable_a_pagar_con_código_de_moneda_ISO__artículo_comercial_de_medida_variable_1
        {
            get
            {
                return AI_3938_Importe_aplicable_a_pagar_con_código_de_moneda_ISO__artículo_comercial_de_medida_variable_;
            }

            set
            {
                AI_3938_Importe_aplicable_a_pagar_con_código_de_moneda_ISO__artículo_comercial_de_medida_variable_ = value;
            }
        }

        public string AI_3939_Importe_aplicable_a_pagar_con_código_de_moneda_ISO__artículo_comercial_de_medida_variable_1
        {
            get
            {
                return AI_3939_Importe_aplicable_a_pagar_con_código_de_moneda_ISO__artículo_comercial_de_medida_variable_;
            }

            set
            {
                AI_3939_Importe_aplicable_a_pagar_con_código_de_moneda_ISO__artículo_comercial_de_medida_variable_ = value;
            }
        }

        public string AI_3940_Porcentaje_de_descuento_de_un_cupón1
        {
            get
            {
                return AI_3940_Porcentaje_de_descuento_de_un_cupón;
            }

            set
            {
                AI_3940_Porcentaje_de_descuento_de_un_cupón = value;
            }
        }

        public string AI_3941_Porcentaje_de_descuento_de_un_cupón1
        {
            get
            {
                return AI_3941_Porcentaje_de_descuento_de_un_cupón;
            }

            set
            {
                AI_3941_Porcentaje_de_descuento_de_un_cupón = value;
            }
        }

        public string AI_3942_Porcentaje_de_descuento_de_un_cupón1
        {
            get
            {
                return AI_3942_Porcentaje_de_descuento_de_un_cupón;
            }

            set
            {
                AI_3942_Porcentaje_de_descuento_de_un_cupón = value;
            }
        }

        public string AI_3943_Porcentaje_de_descuento_de_un_cupón1
        {
            get
            {
                return AI_3943_Porcentaje_de_descuento_de_un_cupón;
            }

            set
            {
                AI_3943_Porcentaje_de_descuento_de_un_cupón = value;
            }
        }

        public string AI_400__Número_de_orden_de_compra_del_cliente1
        {
            get
            {
                return AI_400__Número_de_orden_de_compra_del_cliente;
            }

            set
            {
                AI_400__Número_de_orden_de_compra_del_cliente = value;
            }
        }

        public string AI_401__Número_de_Identificación_Global_para_Consignación__GINC_1
        {
            get
            {
                return AI_401__Número_de_Identificación_Global_para_Consignación__GINC_;
            }

            set
            {
                AI_401__Número_de_Identificación_Global_para_Consignación__GINC_ = value;
            }
        }

        public string AI_402__Número_de_Identificación_Global_de_Envío__GSIN_1
        {
            get
            {
                return AI_402__Número_de_Identificación_Global_de_Envío__GSIN_;
            }

            set
            {
                AI_402__Número_de_Identificación_Global_de_Envío__GSIN_ = value;
            }
        }

        public string AI_403__Código_de_enrutamiento1
        {
            get
            {
                return AI_403__Código_de_enrutamiento;
            }

            set
            {
                AI_403__Código_de_enrutamiento = value;
            }
        }

        public string AI_410__Enviar_a__Enviar_a_Número_Global_de_Localización1
        {
            get
            {
                return AI_410__Enviar_a__Enviar_a_Número_Global_de_Localización;
            }

            set
            {
                AI_410__Enviar_a__Enviar_a_Número_Global_de_Localización = value;
            }
        }

        public string AI_411__Cobrar_a__Facturar_a_Número_Global_de_Localización1
        {
            get
            {
                return AI_411__Cobrar_a__Facturar_a_Número_Global_de_Localización;
            }

            set
            {
                AI_411__Cobrar_a__Facturar_a_Número_Global_de_Localización = value;
            }
        }

        public string AI_412__Comprado_de_Número_Global_de_Localización1
        {
            get
            {
                return AI_412__Comprado_de_Número_Global_de_Localización;
            }

            set
            {
                AI_412__Comprado_de_Número_Global_de_Localización = value;
            }
        }

        public string AI_413__Enviar_para__Entregar__Reenviar_a_Número_Global_de_Localización1
        {
            get
            {
                return AI_413__Enviar_para__Entregar__Reenviar_a_Número_Global_de_Localización;
            }

            set
            {
                AI_413__Enviar_para__Entregar__Reenviar_a_Número_Global_de_Localización = value;
            }
        }

        public string AI_414__Identificación_de_un_lugar_físico__Número_de_Localización_Global1
        {
            get
            {
                return AI_414__Identificación_de_un_lugar_físico__Número_de_Localización_Global;
            }

            set
            {
                AI_414__Identificación_de_un_lugar_físico__Número_de_Localización_Global = value;
            }
        }

        public string AI_415__Número_Global_de_Localización_del_emisor_de_la_factura1
        {
            get
            {
                return AI_415__Número_Global_de_Localización_del_emisor_de_la_factura;
            }

            set
            {
                AI_415__Número_Global_de_Localización_del_emisor_de_la_factura = value;
            }
        }

        public string AI_416__GLN_del_lugar_de_producción_o_servicio1
        {
            get
            {
                return AI_416__GLN_del_lugar_de_producción_o_servicio;
            }

            set
            {
                AI_416__GLN_del_lugar_de_producción_o_servicio = value;
            }
        }

        public string AI_417__GLN_de_la_empresa1
        {
            get
            {
                return AI_417__GLN_de_la_empresa;
            }

            set
            {
                AI_417__GLN_de_la_empresa = value;
            }
        }

        public string AI_420__Enviar_a__Enviar_a_código_postal_dentro_de_una_única_autoridad_postal1
        {
            get
            {
                return AI_420__Enviar_a__Enviar_a_código_postal_dentro_de_una_única_autoridad_postal;
            }

            set
            {
                AI_420__Enviar_a__Enviar_a_código_postal_dentro_de_una_única_autoridad_postal = value;
            }
        }

        public string AI_421__Enviar_a__Enviar_a_código_postal_con_código_de_país_ISO1
        {
            get
            {
                return AI_421__Enviar_a__Enviar_a_código_postal_con_código_de_país_ISO;
            }

            set
            {
                AI_421__Enviar_a__Enviar_a_código_postal_con_código_de_país_ISO = value;
            }
        }

        public string AI_422__País_de_origen_de_un_artículo_comercial1
        {
            get
            {
                return AI_422__País_de_origen_de_un_artículo_comercial;
            }

            set
            {
                AI_422__País_de_origen_de_un_artículo_comercial = value;
            }
        }

        public string AI_423__País_de_procesamiento_inicial1
        {
            get
            {
                return AI_423__País_de_procesamiento_inicial;
            }

            set
            {
                AI_423__País_de_procesamiento_inicial = value;
            }
        }

        public string AI_424__País_de_procesamiento1
        {
            get
            {
                return AI_424__País_de_procesamiento;
            }

            set
            {
                AI_424__País_de_procesamiento = value;
            }
        }

        public string AI_425__País_de_desmontaje1
        {
            get
            {
                return AI_425__País_de_desmontaje;
            }

            set
            {
                AI_425__País_de_desmontaje = value;
            }
        }

        public string AI_426__País_cubriendo_cadena_de_proceso_completa1
        {
            get
            {
                return AI_426__País_cubriendo_cadena_de_proceso_completa;
            }

            set
            {
                AI_426__País_cubriendo_cadena_de_proceso_completa = value;
            }
        }

        public string AI_427__Subdivisión_de_país_de_origen1
        {
            get
            {
                return AI_427__Subdivisión_de_país_de_origen;
            }

            set
            {
                AI_427__Subdivisión_de_país_de_origen = value;
            }
        }

        public string AI_7001_OTAN_Número_de_stock__NSN_1
        {
            get
            {
                return AI_7001_OTAN_Número_de_stock__NSN_;
            }

            set
            {
                AI_7001_OTAN_Número_de_stock__NSN_ = value;
            }
        }

        public string AI_7002_ONU__ECE_clasificación_de_canales_y_cortes_de_carne1
        {
            get
            {
                return AI_7002_ONU__ECE_clasificación_de_canales_y_cortes_de_carne;
            }

            set
            {
                AI_7002_ONU__ECE_clasificación_de_canales_y_cortes_de_carne = value;
            }
        }

        public string AI_7003_Fecha_y_hora_de_caducidad1
        {
            get
            {
                return AI_7003_Fecha_y_hora_de_caducidad;
            }

            set
            {
                AI_7003_Fecha_y_hora_de_caducidad = value;
            }
        }

        public string AI_7004_Potencia_activa1
        {
            get
            {
                return AI_7004_Potencia_activa;
            }

            set
            {
                AI_7004_Potencia_activa = value;
            }
        }

        public string AI_7005_Zona_de_captura1
        {
            get
            {
                return AI_7005_Zona_de_captura;
            }

            set
            {
                AI_7005_Zona_de_captura = value;
            }
        }

        public string AI_7006_Primera_fecha_de_congelación1
        {
            get
            {
                return AI_7006_Primera_fecha_de_congelación;
            }

            set
            {
                AI_7006_Primera_fecha_de_congelación = value;
            }
        }

        public string AI_7007_Fecha_de_cosecha1
        {
            get
            {
                return AI_7007_Fecha_de_cosecha;
            }

            set
            {
                AI_7007_Fecha_de_cosecha = value;
            }
        }

        public string AI_7008_Especies_con_fines_pesqueros1
        {
            get
            {
                return AI_7008_Especies_con_fines_pesqueros;
            }

            set
            {
                AI_7008_Especies_con_fines_pesqueros = value;
            }
        }

        public string AI_7009_Tipo_de_equipo_de_Pesca1
        {
            get
            {
                return AI_7009_Tipo_de_equipo_de_Pesca;
            }

            set
            {
                AI_7009_Tipo_de_equipo_de_Pesca = value;
            }
        }

        public string AI_7010_Método_de_producción1
        {
            get
            {
                return AI_7010_Método_de_producción;
            }

            set
            {
                AI_7010_Método_de_producción = value;
            }
        }

        public string AI_7020_ID_de_lote_remodelación1
        {
            get
            {
                return AI_7020_ID_de_lote_remodelación;
            }

            set
            {
                AI_7020_ID_de_lote_remodelación = value;
            }
        }

        public string AI_7021_Estado_funcional1
        {
            get
            {
                return AI_7021_Estado_funcional;
            }

            set
            {
                AI_7021_Estado_funcional = value;
            }
        }

        public string AI_7022_Estado_de_revisión1
        {
            get
            {
                return AI_7022_Estado_de_revisión;
            }

            set
            {
                AI_7022_Estado_de_revisión = value;
            }
        }

        public string AI_7023_Identificador_Global_de_un_Bien_Individual__GIAI__de_un_ensamblado1
        {
            get
            {
                return AI_7023_Identificador_Global_de_un_Bien_Individual__GIAI__de_un_ensamblado;
            }

            set
            {
                AI_7023_Identificador_Global_de_un_Bien_Individual__GIAI__de_un_ensamblado = value;
            }
        }

        public string AI_7030_Número_de_procesador_con_código_de_país_ISO1
        {
            get
            {
                return AI_7030_Número_de_procesador_con_código_de_país_ISO;
            }

            set
            {
                AI_7030_Número_de_procesador_con_código_de_país_ISO = value;
            }
        }

        public string AI_7031_Número_de_procesador_con_código_de_país_ISO1
        {
            get
            {
                return AI_7031_Número_de_procesador_con_código_de_país_ISO;
            }

            set
            {
                AI_7031_Número_de_procesador_con_código_de_país_ISO = value;
            }
        }

        public string AI_7032_Número_de_procesador_con_código_de_país_ISO1
        {
            get
            {
                return AI_7032_Número_de_procesador_con_código_de_país_ISO;
            }

            set
            {
                AI_7032_Número_de_procesador_con_código_de_país_ISO = value;
            }
        }

        public string AI_7033_Número_de_procesador_con_código_de_país_ISO1
        {
            get
            {
                return AI_7033_Número_de_procesador_con_código_de_país_ISO;
            }

            set
            {
                AI_7033_Número_de_procesador_con_código_de_país_ISO = value;
            }
        }

        public string AI_7034_Número_de_procesador_con_código_de_país_ISO1
        {
            get
            {
                return AI_7034_Número_de_procesador_con_código_de_país_ISO;
            }

            set
            {
                AI_7034_Número_de_procesador_con_código_de_país_ISO = value;
            }
        }

        public string AI_7035_Número_de_procesador_con_código_de_país_ISO1
        {
            get
            {
                return AI_7035_Número_de_procesador_con_código_de_país_ISO;
            }

            set
            {
                AI_7035_Número_de_procesador_con_código_de_país_ISO = value;
            }
        }

        public string AI_7036_Número_de_procesador_con_código_de_país_ISO1
        {
            get
            {
                return AI_7036_Número_de_procesador_con_código_de_país_ISO;
            }

            set
            {
                AI_7036_Número_de_procesador_con_código_de_país_ISO = value;
            }
        }

        public string AI_7037_Número_de_procesador_con_código_de_país_ISO1
        {
            get
            {
                return AI_7037_Número_de_procesador_con_código_de_país_ISO;
            }

            set
            {
                AI_7037_Número_de_procesador_con_código_de_país_ISO = value;
            }
        }

        public string AI_7038_Número_de_procesador_con_código_de_país_ISO1
        {
            get
            {
                return AI_7038_Número_de_procesador_con_código_de_país_ISO;
            }

            set
            {
                AI_7038_Número_de_procesador_con_código_de_país_ISO = value;
            }
        }

        public string AI_7039_Número_de_procesador_con_código_de_país_ISO1
        {
            get
            {
                return AI_7039_Número_de_procesador_con_código_de_país_ISO;
            }

            set
            {
                AI_7039_Número_de_procesador_con_código_de_país_ISO = value;
            }
        }

        public string AI_7040_GS1_UIC_con_extensión_1_e_índice_de_Importador1
        {
            get
            {
                return AI_7040_GS1_UIC_con_extensión_1_e_índice_de_Importador;
            }

            set
            {
                AI_7040_GS1_UIC_con_extensión_1_e_índice_de_Importador = value;
            }
        }

        public string AI_710__Número_nacional_de_reembolso_en_Salud__NHRN___PZN_Alemania1
        {
            get
            {
                return AI_710__Número_nacional_de_reembolso_en_Salud__NHRN___PZN_Alemania;
            }

            set
            {
                AI_710__Número_nacional_de_reembolso_en_Salud__NHRN___PZN_Alemania = value;
            }
        }

        public string AI_711__Número_nacional_de_reembolso_en_Salud__NHRN___CIP_Francia1
        {
            get
            {
                return AI_711__Número_nacional_de_reembolso_en_Salud__NHRN___CIP_Francia;
            }

            set
            {
                AI_711__Número_nacional_de_reembolso_en_Salud__NHRN___CIP_Francia = value;
            }
        }

        public string AI_712__Número_nacional_de_reembolso_en_Salud__NHRN___CN_España1
        {
            get
            {
                return AI_712__Número_nacional_de_reembolso_en_Salud__NHRN___CN_España;
            }

            set
            {
                AI_712__Número_nacional_de_reembolso_en_Salud__NHRN___CN_España = value;
            }
        }

        public string AI_713__Número_nacional_de_reembolso_en_Salud__NHRN___DRN_Brasil1
        {
            get
            {
                return AI_713__Número_nacional_de_reembolso_en_Salud__NHRN___DRN_Brasil;
            }

            set
            {
                AI_713__Número_nacional_de_reembolso_en_Salud__NHRN___DRN_Brasil = value;
            }
        }

        public string AI_714__Número_nacional_de_reembolso_en_Salud__NHRN___AIM_Portugal1
        {
            get
            {
                return AI_714__Número_nacional_de_reembolso_en_Salud__NHRN___AIM_Portugal;
            }

            set
            {
                AI_714__Número_nacional_de_reembolso_en_Salud__NHRN___AIM_Portugal = value;
            }
        }

        public string AI_7230_Referencia_para_la_certificación1
        {
            get
            {
                return AI_7230_Referencia_para_la_certificación;
            }

            set
            {
                AI_7230_Referencia_para_la_certificación = value;
            }
        }

        public string AI_7231_Referencia_para_la_certificación1
        {
            get
            {
                return AI_7231_Referencia_para_la_certificación;
            }

            set
            {
                AI_7231_Referencia_para_la_certificación = value;
            }
        }

        public string AI_7232_Referencia_para_la_certificación1
        {
            get
            {
                return AI_7232_Referencia_para_la_certificación;
            }

            set
            {
                AI_7232_Referencia_para_la_certificación = value;
            }
        }

        public string AI_7233_Referencia_para_la_certificación1
        {
            get
            {
                return AI_7233_Referencia_para_la_certificación;
            }

            set
            {
                AI_7233_Referencia_para_la_certificación = value;
            }
        }

        public string AI_7234_Referencia_para_la_certificación1
        {
            get
            {
                return AI_7234_Referencia_para_la_certificación;
            }

            set
            {
                AI_7234_Referencia_para_la_certificación = value;
            }
        }

        public string AI_7235_Referencia_para_la_certificación1
        {
            get
            {
                return AI_7235_Referencia_para_la_certificación;
            }

            set
            {
                AI_7235_Referencia_para_la_certificación = value;
            }
        }

        public string AI_7236_Referencia_para_la_certificación1
        {
            get
            {
                return AI_7236_Referencia_para_la_certificación;
            }

            set
            {
                AI_7236_Referencia_para_la_certificación = value;
            }
        }

        public string AI_7237_Referencia_para_la_certificación1
        {
            get
            {
                return AI_7237_Referencia_para_la_certificación;
            }

            set
            {
                AI_7237_Referencia_para_la_certificación = value;
            }
        }

        public string AI_7238_Referencia_para_la_certificación1
        {
            get
            {
                return AI_7238_Referencia_para_la_certificación;
            }

            set
            {
                AI_7238_Referencia_para_la_certificación = value;
            }
        }

        public string AI_7239_Referencia_para_la_certificación1
        {
            get
            {
                return AI_7239_Referencia_para_la_certificación;
            }

            set
            {
                AI_7239_Referencia_para_la_certificación = value;
            }
        }

        public string AI_7240_ID_de_protocolo1
        {
            get
            {
                return AI_7240_ID_de_protocolo;
            }

            set
            {
                AI_7240_ID_de_protocolo = value;
            }
        }

        public string AI_8001_Número_nacional_de_reembolso_en_Salud__NHRN___NHRN_País_A1
        {
            get
            {
                return AI_8001_Número_nacional_de_reembolso_en_Salud__NHRN___NHRN_País_A;
            }

            set
            {
                AI_8001_Número_nacional_de_reembolso_en_Salud__NHRN___NHRN_País_A = value;
            }
        }

        public string AI_8002_Identificador_de_telefonía_móvil_celular1
        {
            get
            {
                return AI_8002_Identificador_de_telefonía_móvil_celular;
            }

            set
            {
                AI_8002_Identificador_de_telefonía_móvil_celular = value;
            }
        }

        public string AI_8003_Identificador_Global_de_Bien_Retornable__GRAI_1
        {
            get
            {
                return AI_8003_Identificador_Global_de_Bien_Retornable__GRAI_;
            }

            set
            {
                AI_8003_Identificador_Global_de_Bien_Retornable__GRAI_ = value;
            }
        }

        public string AI_8004_Identificador_Global_de_Bien_Individual__GIAI_1
        {
            get
            {
                return AI_8004_Identificador_Global_de_Bien_Individual__GIAI_;
            }

            set
            {
                AI_8004_Identificador_Global_de_Bien_Individual__GIAI_ = value;
            }
        }

        public string AI_8005_Precio_por_unidad_de_medida1
        {
            get
            {
                return AI_8005_Precio_por_unidad_de_medida;
            }

            set
            {
                AI_8005_Precio_por_unidad_de_medida = value;
            }
        }

        public string AI_8006_Identification_of_an_individual_trade_item_piece1
        {
            get
            {
                return AI_8006_Identification_of_an_individual_trade_item_piece;
            }

            set
            {
                AI_8006_Identification_of_an_individual_trade_item_piece = value;
            }
        }

        public string AI_8007_Número_de_cuenta_bancaria_internacional__IBAN_1
        {
            get
            {
                return AI_8007_Número_de_cuenta_bancaria_internacional__IBAN_;
            }

            set
            {
                AI_8007_Número_de_cuenta_bancaria_internacional__IBAN_ = value;
            }
        }

        public string AI_8008_Fecha_y_hora_de_la_producción1
        {
            get
            {
                return AI_8008_Fecha_y_hora_de_la_producción;
            }

            set
            {
                AI_8008_Fecha_y_hora_de_la_producción = value;
            }
        }

        public string AI_8009_Indicador_del_sensor_ópticamente_legible1
        {
            get
            {
                return AI_8009_Indicador_del_sensor_ópticamente_legible;
            }

            set
            {
                AI_8009_Indicador_del_sensor_ópticamente_legible = value;
            }
        }

        public string AI_8010_Identificador_de_componente__parte__CPID_1
        {
            get
            {
                return AI_8010_Identificador_de_componente__parte__CPID_;
            }

            set
            {
                AI_8010_Identificador_de_componente__parte__CPID_ = value;
            }
        }

        public string AI_8011_Número_de_serie_de_identificador_de_componente__parte_de__CPID_DE_SERIE_1
        {
            get
            {
                return AI_8011_Número_de_serie_de_identificador_de_componente__parte_de__CPID_DE_SERIE_;
            }

            set
            {
                AI_8011_Número_de_serie_de_identificador_de_componente__parte_de__CPID_DE_SERIE_ = value;
            }
        }

        public string AI_8012_Versión_del_software1
        {
            get
            {
                return AI_8012_Versión_del_software;
            }

            set
            {
                AI_8012_Versión_del_software = value;
            }
        }

        public string AI_8013_Número_Global_de_Modelo__GMN_1
        {
            get
            {
                return AI_8013_Número_Global_de_Modelo__GMN_;
            }

            set
            {
                AI_8013_Número_Global_de_Modelo__GMN_ = value;
            }
        }

        public string AI_8017_Número_de_Relación_de_Servicio_Global_para_identificar_la_relación_entre_una_organización_que_ofrece_servicios_y_el_proveedor_de_los_servicios1
        {
            get
            {
                return AI_8017_Número_de_Relación_de_Servicio_Global_para_identificar_la_relación_entre_una_organización_que_ofrece_servicios_y_el_proveedor_de_los_servicios;
            }

            set
            {
                AI_8017_Número_de_Relación_de_Servicio_Global_para_identificar_la_relación_entre_una_organización_que_ofrece_servicios_y_el_proveedor_de_los_servicios = value;
            }
        }

        public string AI_8018_Número_de_Relación_de_Servicio_Global_para_identificar_la_relación_entre_una_organización_que_ofrece_servicios_y_el_receptor_de_los_servicios1
        {
            get
            {
                return AI_8018_Número_de_Relación_de_Servicio_Global_para_identificar_la_relación_entre_una_organización_que_ofrece_servicios_y_el_receptor_de_los_servicios;
            }

            set
            {
                AI_8018_Número_de_Relación_de_Servicio_Global_para_identificar_la_relación_entre_una_organización_que_ofrece_servicios_y_el_receptor_de_los_servicios = value;
            }
        }

        public string AI_8019_Número_de_instancia_de_relación_de_servicio__SRIN_1
        {
            get
            {
                return AI_8019_Número_de_instancia_de_relación_de_servicio__SRIN_;
            }

            set
            {
                AI_8019_Número_de_instancia_de_relación_de_servicio__SRIN_ = value;
            }
        }

        public string AI_8020_Número_de_referencia_de_comprobante_de_pago1
        {
            get
            {
                return AI_8020_Número_de_referencia_de_comprobante_de_pago;
            }

            set
            {
                AI_8020_Número_de_referencia_de_comprobante_de_pago = value;
            }
        }

        public string AI_8026_Identificación_de_las_piezas_de_un_artículo_comercial__ITIP__contenidas_en_una_unidad_logística1
        {
            get
            {
                return AI_8026_Identificación_de_las_piezas_de_un_artículo_comercial__ITIP__contenidas_en_una_unidad_logística;
            }

            set
            {
                AI_8026_Identificación_de_las_piezas_de_un_artículo_comercial__ITIP__contenidas_en_una_unidad_logística = value;
            }
        }

        public string AI_8110_Identificación_de_código_de_cupón_para_uso_en_Norte_América1
        {
            get
            {
                return AI_8110_Identificación_de_código_de_cupón_para_uso_en_Norte_América;
            }

            set
            {
                AI_8110_Identificación_de_código_de_cupón_para_uso_en_Norte_América = value;
            }
        }

        public string AI_8111_Puntos_de_fidelidad_de_un_cupón1
        {
            get
            {
                return AI_8111_Puntos_de_fidelidad_de_un_cupón;
            }

            set
            {
                AI_8111_Puntos_de_fidelidad_de_un_cupón = value;
            }
        }

        public string AI_8112_Identificación_de_código_de_cupón_sin_papel_para_uso_en_América_del_Norte1
        {
            get
            {
                return AI_8112_Identificación_de_código_de_cupón_sin_papel_para_uso_en_América_del_Norte;
            }

            set
            {
                AI_8112_Identificación_de_código_de_cupón_sin_papel_para_uso_en_América_del_Norte = value;
            }
        }

        public string AI_8200_URL_de_embalaje_extendido1
        {
            get
            {
                return AI_8200_URL_de_embalaje_extendido;
            }

            set
            {
                AI_8200_URL_de_embalaje_extendido = value;
            }
        }

        public string AI_90___Información_de_mutuo_acuerdo_entre_socios_comerciales1
        {
            get
            {
                return AI_90___Información_de_mutuo_acuerdo_entre_socios_comerciales;
            }

            set
            {
                AI_90___Información_de_mutuo_acuerdo_entre_socios_comerciales = value;
            }
        }

        public string AI_91___Información_interna_de_compañía1
        {
            get
            {
                return AI_91___Información_interna_de_compañía;
            }

            set
            {
                AI_91___Información_interna_de_compañía = value;
            }
        }

        public string AI_92___Información_interna_de_compañía1
        {
            get
            {
                return AI_92___Información_interna_de_compañía;
            }

            set
            {
                AI_92___Información_interna_de_compañía = value;
            }
        }

        public string AI_93___Información_interna_de_compañía1
        {
            get
            {
                return AI_93___Información_interna_de_compañía;
            }

            set
            {
                AI_93___Información_interna_de_compañía = value;
            }
        }

        public string AI_94___Información_interna_de_compañía1
        {
            get
            {
                return AI_94___Información_interna_de_compañía;
            }

            set
            {
                AI_94___Información_interna_de_compañía = value;
            }
        }

        public string AI_95___Información_interna_de_compañía1
        {
            get
            {
                return AI_95___Información_interna_de_compañía;
            }

            set
            {
                AI_95___Información_interna_de_compañía = value;
            }
        }

        public string AI_96___Información_interna_de_compañía1
        {
            get
            {
                return AI_96___Información_interna_de_compañía;
            }

            set
            {
                AI_96___Información_interna_de_compañía = value;
            }
        }

        public string AI_97___Información_interna_de_compañía1
        {
            get
            {
                return AI_97___Información_interna_de_compañía;
            }

            set
            {
                AI_97___Información_interna_de_compañía = value;
            }
        }

        public string AI_98___Información_interna_de_compañía1
        {
            get
            {
                return AI_98___Información_interna_de_compañía;
            }

            set
            {
                AI_98___Información_interna_de_compañía = value;
            }
        }

        public string AI_99___Información_interna_de_compañía1
        {
            get
            {
                return AI_99___Información_interna_de_compañía;
            }

            set
            {
                AI_99___Información_interna_de_compañía = value;
            }
        }

        #endregion

        public Ean128()
        {
            // https://www.gs1.org/standards/barcodes/application-identifiers?lang=es
            // Ejemplo: (02)08000607997453(10)LB246(15)070831(37)72    020800060799745310LB246150708313772
            ia[000] = new ApplicationIdentifiers("AI", "Descripción                                                                                                                                     ", "Formato     ", "Título                                                                ", "FNC1", @"Expresión regular", "", 0);
            ia[001] = new ApplicationIdentifiers("00", "Código Seriado de Contenedor de Embarque(SSCC)                                                                                                  ", "N2+N18      ", "SSCC                                                                  ", "No  ", @"^00(\d{18})", "", 0);
            ia[002] = new ApplicationIdentifiers("01", "Número Global de Artículo Comercial(GTIN)                                                                                                       ", "N2+N14      ", "GTIN                                                                  ", "No  ", @"^01(\d{14})", "", 0);
            ia[003] = new ApplicationIdentifiers("02", "GTIN de los artículos comerciales contenidos                                                                                                    ", "N2+N14      ", "CONTENT                                                               ", "No  ", @"^02(\d{14})", "", 0);
            ia[004] = new ApplicationIdentifiers("10", "Lote o número de lote                                                                                                                           ", "N2+X..20    ", "BATCH/LOT                                                             ", "Si  ", @"^10([\x21-\x22\x25-\x2F\x30-\x39\x41-\x5A\x5F\x61-\x7A]{0,20})", "", 0);
            ia[005] = new ApplicationIdentifiers("11", "Fecha de producción(AAMMDD)                                                                                                                     ", "N2+N6       ", "PROD DATE                                                             ", "No  ", @"^11(\d{6})", "", 0);
            ia[006] = new ApplicationIdentifiers("12", "Fecha de vencimiento de pago(AAMMDD)                                                                                                            ", "N2+N6       ", "DUE DATE                                                              ", "No  ", @"^12(\d{6})", "", 0);
            ia[007] = new ApplicationIdentifiers("13", "Fecha de envasado(AAMMDD)                                                                                                                       ", "N2+N6       ", "PACK DATE                                                             ", "No  ", @"^13(\d{6})", "", 0);
            ia[008] = new ApplicationIdentifiers("15", "Fecha de consumo preferente(AAMMDD)                                                                                                             ", "N2+N6       ", "BEST BEFORE or BEST BY                                                ", "No  ", @"^15(\d{6})", "", 0);
            ia[009] = new ApplicationIdentifiers("16", "Última fecha de venta(AAMMDD)                                                                                                                   ", "N2+N6       ", "SELL BY                                                               ", "No  ", @"^16(\d{6})", "", 0);
            ia[010] = new ApplicationIdentifiers("17", "Fecha de vencimiento(AAMMDD)                                                                                                                    ", "N2+N6       ", "USE BY OR EXPIRY                                                      ", "No  ", @"^17(\d{6})", "", 0);
            ia[011] = new ApplicationIdentifiers("20", "Variante de producto interno                                                                                                                    ", "N2+N2       ", "VARIANT                                                               ", "No  ", @"^20(\d{2})", "", 0);
            ia[012] = new ApplicationIdentifiers("21", "Número de serie                                                                                                                                 ", "N2+X..20    ", "SERIAL                                                                ", "Si  ", @"^21([\x21-\x22\x25-\x2F\x30-\x39\x41-\x5A\x5F\x61-\x7A]{0,20})", "", 0);
            ia[013] = new ApplicationIdentifiers("22", "Variante de producto de consumo                                                                                                                 ", "N2+X..20    ", "CPV                                                                   ", "Si  ", @"^22([\x21-\x22\x25-\x2F\x30-\x39\x41-\x5A\x5F\x61-\x7A]{0,20})", "", 0);
            ia[014] = new ApplicationIdentifiers("235", "Extensión serializada controlada de GTIN de terceros(TPX)                                                                                      ", "N3+X..28    ", "TPX                                                                   ", "No  ", @"^235([\x21-\x22\x25-\x2F\x30-\x39\x41-\x5A\x5F\x61-\x7A]{0,28})", "", 0);
            ia[015] = new ApplicationIdentifiers("240", "Identificación de producto adicional asignado por el fabricante                                                                                ", "N3+X..30    ", "ADDITIONAL ID                                                         ", "Si  ", @"^240([\x21-\x22\x25-\x2F\x30-\x39\x41-\x5A\x5F\x61-\x7A]{0,30})", "", 0);
            ia[016] = new ApplicationIdentifiers("241", "Número de pieza del cliente                                                                                                                    ", "N3+X..30    ", "CUST.PART NO.                                                         ", "Si  ", @"^241([\x21-\x22\x25-\x2F\x30-\x39\x41-\x5A\x5F\x61-\x7A]{ 0,30})", "", 0);
            ia[017] = new ApplicationIdentifiers("242", "Número de variación de “mandado a hacer”                                                                                                       ", "N3+N..6     ", "MTO VARIANT                                                           ", "Si  ", @"^242(\d{0,6})", "", 0);
            ia[018] = new ApplicationIdentifiers("243", "Número de componente de empaque                                                                                                                ", "N3+X..20    ", "PCN                                                                   ", "Si  ", @"^243([\x21-\x22\x25-\x2F\x30-\x39\x41-\x5A\x5F\x61-\x7A]{0,20})", "", 0);
            ia[019] = new ApplicationIdentifiers("250", "Número de serie secundario                                                                                                                     ", "N3+X..30    ", "SECONDARY SERIAL                                                      ", "Si  ", @"^250([\x21-\x22\x25-\x2F\x30-\x39\x41-\x5A\x5F\x61-\x7A]{0,30})", "", 0);
            ia[020] = new ApplicationIdentifiers("251", "Referencia a la entidad de origen                                                                                                              ", "N3+X..30    ", "REF.TO SOURCE                                                         ", "Si  ", @"^251([\x21-\x22\x25-\x2F\x30-\x39\x41-\x5A\x5F\x61-\x7A]{0,30})", "", 0);
            ia[021] = new ApplicationIdentifiers("253", "Identificador de tipo de documento global(GDTI)                                                                                                ", "N3+N13+X..17", "GDTI                                                                  ", "Si  ", @"^253(\d{13})([\x21-\x22\x25-\x2F\x30-\x39\x41-\x5A\x5F\x61-\x7A]{0,17})", "", 0);
            ia[022] = new ApplicationIdentifiers("254", "Componente de extensión del GLN                                                                                                                ", "N3+X..20    ", "GLN EXTENSION COMPONENT                                               ", "Si  ", @"^254([\x21-\x22\x25-\x2F\x30-\x39\x41-\x5A\x5F\x61-\x7A]{0,20})", "", 0);
            ia[023] = new ApplicationIdentifiers("255", "Número de cupón global(GCN)                                                                                                                    ", "N3+N13+N..12", "GCN                                                                   ", "Si  ", @"^255(\d{13})(\d{0,12})", "", 0);
            ia[024] = new ApplicationIdentifiers("30", "Conteo variable de artículos(artículo comercial de medidas variables)                                                                           ", "N2+N..8     ", "VAR.COUNT                                                             ", "Si  ", @"^30(\d{0,8})", "", 0);
            ia[025] = new ApplicationIdentifiers("3100", "Peso neto, kilogramos (artículo comercial de medidas variables)                                                                               ", "N4+N6       ", "NET WEIGHT (kg)                                                       ", "No  ", @"^3100(\d{6})", "", 0);
            ia[026] = new ApplicationIdentifiers("3101", "Peso neto, kilogramos (artículo comercial de medidas variables)                                                                               ", "N4+N6       ", "NET WEIGHT (kg)                                                       ", "No  ", @"^3101(\d{6})", "", 0);
            ia[027] = new ApplicationIdentifiers("3102", "Peso neto, kilogramos (artículo comercial de medidas variables)                                                                               ", "N4+N6       ", "NET WEIGHT (kg)                                                       ", "No  ", @"^3102(\d{6})", "", 0);
            ia[028] = new ApplicationIdentifiers("3103", "Peso neto, kilogramos (artículo comercial de medidas variables)                                                                               ", "N4+N6       ", "NET WEIGHT (kg)                                                       ", "No  ", @"^3103(\d{6})", "", 0);
            ia[029] = new ApplicationIdentifiers("3104", "Peso neto, kilogramos (artículo comercial de medidas variables)                                                                               ", "N4+N6       ", "NET WEIGHT (kg)                                                       ", "No  ", @"^3104(\d{6})", "", 0);
            ia[030] = new ApplicationIdentifiers("3105", "Peso neto, kilogramos (artículo comercial de medidas variables)                                                                               ", "N4+N6       ", "NET WEIGHT (kg)                                                       ", "No  ", @"^3105(\d{6})", "", 0);
            ia[031] = new ApplicationIdentifiers("3110", "Longitud o primera dimensión, metros (artículo comercial de medidas variables)                                                                ", "N4+N6       ", "LENGTH (m)                                                            ", "No  ", @"^3110(\d{6})", "", 0);
            ia[032] = new ApplicationIdentifiers("3111", "Longitud o primera dimensión, metros (artículo comercial de medidas variables)                                                                ", "N4+N6       ", "LENGTH (m)                                                            ", "No  ", @"^3111(\d{6})", "", 0);
            ia[033] = new ApplicationIdentifiers("3112", "Longitud o primera dimensión, metros (artículo comercial de medidas variables)                                                                ", "N4+N6       ", "LENGTH (m)                                                            ", "No  ", @"^3112(\d{6})", "", 0);
            ia[034] = new ApplicationIdentifiers("3113", "Longitud o primera dimensión, metros (artículo comercial de medidas variables)                                                                ", "N4+N6       ", "LENGTH (m)                                                            ", "No  ", @"^3113(\d{6})", "", 0);
            ia[035] = new ApplicationIdentifiers("3114", "Longitud o primera dimensión, metros (artículo comercial de medidas variables)                                                                ", "N4+N6       ", "LENGTH (m)                                                            ", "No  ", @"^3114(\d{6})", "", 0);
            ia[036] = new ApplicationIdentifiers("3115", "Longitud o primera dimensión, metros (artículo comercial de medidas variables)                                                                ", "N4+N6       ", "LENGTH (m)                                                            ", "No  ", @"^3115(\d{6})", "", 0);
            ia[037] = new ApplicationIdentifiers("3120", "Ancho, diámetro, o segunda dimensión, metros (artículo comercial de medidas variables)                                                        ", "N4+N6       ", "WIDTH (m)                                                             ", "No  ", @"^3120(\d{6})", "", 0);
            ia[038] = new ApplicationIdentifiers("3121", "Ancho, diámetro, o segunda dimensión, metros (artículo comercial de medidas variables)                                                        ", "N4+N6       ", "WIDTH (m)                                                             ", "No  ", @"^3121(\d{6})", "", 0);
            ia[039] = new ApplicationIdentifiers("3122", "Ancho, diámetro, o segunda dimensión, metros (artículo comercial de medidas variables)                                                        ", "N4+N6       ", "WIDTH (m)                                                             ", "No  ", @"^3122(\d{6})", "", 0);
            ia[040] = new ApplicationIdentifiers("3123", "Ancho, diámetro, o segunda dimensión, metros (artículo comercial de medidas variables)                                                        ", "N4+N6       ", "WIDTH (m)                                                             ", "No  ", @"^3123(\d{6})", "", 0);
            ia[041] = new ApplicationIdentifiers("3124", "Ancho, diámetro, o segunda dimensión, metros (artículo comercial de medidas variables)                                                        ", "N4+N6       ", "WIDTH (m)                                                             ", "No  ", @"^3124(\d{6})", "", 0);
            ia[042] = new ApplicationIdentifiers("3125", "Ancho, diámetro, o segunda dimensión, metros (artículo comercial de medidas variables)                                                        ", "N4+N6       ", "WIDTH (m)                                                             ", "No  ", @"^3125(\d{6})", "", 0);
            ia[043] = new ApplicationIdentifiers("3130", "Profundidad, grosor, altura, o tercera dimensión, metros (artículo comercial de medidas variables)                                            ", "N4+N6       ", "HEIGHT (m)                                                            ", "No  ", @"^3130(\d{6})", "", 0);
            ia[044] = new ApplicationIdentifiers("3131", "Profundidad, grosor, altura, o tercera dimensión, metros (artículo comercial de medidas variables)                                            ", "N4+N6       ", "HEIGHT (m)                                                            ", "No  ", @"^3131(\d{6})", "", 0);
            ia[045] = new ApplicationIdentifiers("3132", "Profundidad, grosor, altura, o tercera dimensión, metros (artículo comercial de medidas variables)                                            ", "N4+N6       ", "HEIGHT (m)                                                            ", "No  ", @"^3132(\d{6})", "", 0);
            ia[046] = new ApplicationIdentifiers("3133", "Profundidad, grosor, altura, o tercera dimensión, metros (artículo comercial de medidas variables)                                            ", "N4+N6       ", "HEIGHT (m)                                                            ", "No  ", @"^3133(\d{6})", "", 0);
            ia[047] = new ApplicationIdentifiers("3134", "Profundidad, grosor, altura, o tercera dimensión, metros (artículo comercial de medidas variables)                                            ", "N4+N6       ", "HEIGHT (m)                                                            ", "No  ", @"^3134(\d{6})", "", 0);
            ia[048] = new ApplicationIdentifiers("3135", "Profundidad, grosor, altura, o tercera dimensión, metros (artículo comercial de medidas variables)                                            ", "N4+N6       ", "HEIGHT (m)                                                            ", "No  ", @"^3135(\d{6})", "", 0);
            ia[049] = new ApplicationIdentifiers("3140", "Área, metros cuadrados (artículo comercial de medidas variables)                                                                              ", "N4+N6       ", "AREA (m2)                                                             ", "No  ", @"^3140(\d{6})", "", 0);
            ia[050] = new ApplicationIdentifiers("3141", "Área, metros cuadrados (artículo comercial de medidas variables)                                                                              ", "N4+N6       ", "AREA (m2)                                                             ", "No  ", @"^3141(\d{6})", "", 0);
            ia[051] = new ApplicationIdentifiers("3142", "Área, metros cuadrados (artículo comercial de medidas variables)                                                                              ", "N4+N6       ", "AREA (m2)                                                             ", "No  ", @"^3142(\d{6})", "", 0);
            ia[052] = new ApplicationIdentifiers("3143", "Área, metros cuadrados (artículo comercial de medidas variables)                                                                              ", "N4+N6       ", "AREA (m2)                                                             ", "No  ", @"^3143(\d{6})", "", 0);
            ia[053] = new ApplicationIdentifiers("3144", "Área, metros cuadrados (artículo comercial de medidas variables)                                                                              ", "N4+N6       ", "AREA (m2)                                                             ", "No  ", @"^3144(\d{6})", "", 0);
            ia[054] = new ApplicationIdentifiers("3145", "Área, metros cuadrados (artículo comercial de medidas variables)                                                                              ", "N4+N6       ", "AREA (m2)                                                             ", "No  ", @"^3145(\d{6})", "", 0);
            ia[055] = new ApplicationIdentifiers("3150", "Volumen neto, litros (artículo comercial de medidas variables)                                                                                ", "N4+N6       ", "NET VOLUME (l)                                                        ", "No  ", @"^3150(\d{6})", "", 0);
            ia[056] = new ApplicationIdentifiers("3151", "Volumen neto, litros (artículo comercial de medidas variables)                                                                                ", "N4+N6       ", "NET VOLUME (l)                                                        ", "No  ", @"^3151(\d{6})", "", 0);
            ia[057] = new ApplicationIdentifiers("3152", "Volumen neto, litros (artículo comercial de medidas variables)                                                                                ", "N4+N6       ", "NET VOLUME (l)                                                        ", "No  ", @"^3152(\d{6})", "", 0);
            ia[058] = new ApplicationIdentifiers("3153", "Volumen neto, litros (artículo comercial de medidas variables)                                                                                ", "N4+N6       ", "NET VOLUME (l)                                                        ", "No  ", @"^3153(\d{6})", "", 0);
            ia[059] = new ApplicationIdentifiers("3154", "Volumen neto, litros (artículo comercial de medidas variables)                                                                                ", "N4+N6       ", "NET VOLUME (l)                                                        ", "No  ", @"^3154(\d{6})", "", 0);
            ia[060] = new ApplicationIdentifiers("3155", "Volumen neto, litros (artículo comercial de medidas variables)                                                                                ", "N4+N6       ", "NET VOLUME (l)                                                        ", "No  ", @"^3155(\d{6})", "", 0);
            ia[061] = new ApplicationIdentifiers("3160", "Volumen neto, metros cúbicos (artículo comercial de medidas variables)                                                                        ", "N4+N6       ", "NET VOLUME (m3)                                                       ", "No  ", @"^3160(\d{6})", "", 0);
            ia[062] = new ApplicationIdentifiers("3161", "Volumen neto, metros cúbicos (artículo comercial de medidas variables)                                                                        ", "N4+N6       ", "NET VOLUME (m3)                                                       ", "No  ", @"^3161(\d{6})", "", 0);
            ia[063] = new ApplicationIdentifiers("3162", "Volumen neto, metros cúbicos (artículo comercial de medidas variables)                                                                        ", "N4+N6       ", "NET VOLUME (m3)                                                       ", "No  ", @"^3162(\d{6})", "", 0);
            ia[064] = new ApplicationIdentifiers("3163", "Volumen neto, metros cúbicos (artículo comercial de medidas variables)                                                                        ", "N4+N6       ", "NET VOLUME (m3)                                                       ", "No  ", @"^3163(\d{6})", "", 0);
            ia[065] = new ApplicationIdentifiers("3164", "Volumen neto, metros cúbicos (artículo comercial de medidas variables)                                                                        ", "N4+N6       ", "NET VOLUME (m3)                                                       ", "No  ", @"^3164(\d{6})", "", 0);
            ia[066] = new ApplicationIdentifiers("3165", "Volumen neto, metros cúbicos (artículo comercial de medidas variables)                                                                        ", "N4+N6       ", "NET VOLUME (m3)                                                       ", "No  ", @"^3165(\d{6})", "", 0);
            ia[067] = new ApplicationIdentifiers("3200", "Peso neto, libras (artículo comercial de medidas variables)                                                                                   ", "N4+N6       ", "NET WEIGHT (lb)                                                       ", "No  ", @"^3200(\d{6})", "", 0);
            ia[068] = new ApplicationIdentifiers("3201", "Peso neto, libras (artículo comercial de medidas variables)                                                                                   ", "N4+N6       ", "NET WEIGHT (lb)                                                       ", "No  ", @"^3201(\d{6})", "", 0);
            ia[069] = new ApplicationIdentifiers("3202", "Peso neto, libras (artículo comercial de medidas variables)                                                                                   ", "N4+N6       ", "NET WEIGHT (lb)                                                       ", "No  ", @"^3202(\d{6})", "", 0);
            ia[070] = new ApplicationIdentifiers("3203", "Peso neto, libras (artículo comercial de medidas variables)                                                                                   ", "N4+N6       ", "NET WEIGHT (lb)                                                       ", "No  ", @"^3203(\d{6})", "", 0);
            ia[071] = new ApplicationIdentifiers("3204", "Peso neto, libras (artículo comercial de medidas variables)                                                                                   ", "N4+N6       ", "NET WEIGHT (lb)                                                       ", "No  ", @"^3204(\d{6})", "", 0);
            ia[072] = new ApplicationIdentifiers("3205", "Peso neto, libras (artículo comercial de medidas variables)                                                                                   ", "N4+N6       ", "NET WEIGHT (lb)                                                       ", "No  ", @"^3205(\d{6})", "", 0);
            ia[073] = new ApplicationIdentifiers("3210", "Longitud o primera dimensión, pulgadas (artículo comercial de medidas variables)                                                              ", "N4+N6       ", "LENGTH (in)                                                           ", "No  ", @"^3210(\d{6})", "", 0);
            ia[074] = new ApplicationIdentifiers("3211", "Longitud o primera dimensión, pulgadas (artículo comercial de medidas variables)                                                              ", "N4+N6       ", "LENGTH (in)                                                           ", "No  ", @"^3211(\d{6})", "", 0);
            ia[075] = new ApplicationIdentifiers("3212", "Longitud o primera dimensión, pulgadas (artículo comercial de medidas variables)                                                              ", "N4+N6       ", "LENGTH (in)                                                           ", "No  ", @"^3212(\d{6})", "", 0);
            ia[076] = new ApplicationIdentifiers("3213", "Longitud o primera dimensión, pulgadas (artículo comercial de medidas variables)                                                              ", "N4+N6       ", "LENGTH (in)                                                           ", "No  ", @"^3213(\d{6})", "", 0);
            ia[077] = new ApplicationIdentifiers("3214", "Longitud o primera dimensión, pulgadas (artículo comercial de medidas variables)                                                              ", "N4+N6       ", "LENGTH (in)                                                           ", "No  ", @"^3214(\d{6})", "", 0);
            ia[078] = new ApplicationIdentifiers("3215", "Longitud o primera dimensión, pulgadas (artículo comercial de medidas variables)                                                              ", "N4+N6       ", "LENGTH (in)                                                           ", "No  ", @"^3215(\d{6})", "", 0);
            ia[079] = new ApplicationIdentifiers("3220", "Longitud o primera dimensión, pies (artículo comercial de medidas variables)                                                                  ", "N4+N6       ", "LENGTH (ft)                                                           ", "No  ", @"^3220(\d{6})", "", 0);
            ia[080] = new ApplicationIdentifiers("3221", "Longitud o primera dimensión, pies (artículo comercial de medidas variables)                                                                  ", "N4+N6       ", "LENGTH (ft)                                                           ", "No  ", @"^3221(\d{6})", "", 0);
            ia[081] = new ApplicationIdentifiers("3222", "Longitud o primera dimensión, pies (artículo comercial de medidas variables)                                                                  ", "N4+N6       ", "LENGTH (ft)                                                           ", "No  ", @"^3222(\d{6})", "", 0);
            ia[082] = new ApplicationIdentifiers("3223", "Longitud o primera dimensión, pies (artículo comercial de medidas variables)                                                                  ", "N4+N6       ", "LENGTH (ft)                                                           ", "No  ", @"^3223(\d{6})", "", 0);
            ia[083] = new ApplicationIdentifiers("3224", "Longitud o primera dimensión, pies (artículo comercial de medidas variables)                                                                  ", "N4+N6       ", "LENGTH (ft)                                                           ", "No  ", @"^3224(\d{6})", "", 0);
            ia[084] = new ApplicationIdentifiers("3225", "Longitud o primera dimensión, pies (artículo comercial de medidas variables)                                                                  ", "N4+N6       ", "LENGTH (ft)                                                           ", "No  ", @"^3225(\d{6})", "", 0);
            ia[085] = new ApplicationIdentifiers("3230", "Longitud o primera dimensión, yardas (artículo comercial de medidas variables)                                                                ", "N4+N6       ", "LENGTH (yd)                                                           ", "No  ", @"^3230(\d{6})", "", 0);
            ia[086] = new ApplicationIdentifiers("3231", "Longitud o primera dimensión, yardas (artículo comercial de medidas variables)                                                                ", "N4+N6       ", "LENGTH (yd)                                                           ", "No  ", @"^3231(\d{6})", "", 0);
            ia[087] = new ApplicationIdentifiers("3232", "Longitud o primera dimensión, yardas (artículo comercial de medidas variables)                                                                ", "N4+N6       ", "LENGTH (yd)                                                           ", "No  ", @"^3232(\d{6})", "", 0);
            ia[088] = new ApplicationIdentifiers("3233", "Longitud o primera dimensión, yardas (artículo comercial de medidas variables)                                                                ", "N4+N6       ", "LENGTH (yd)                                                           ", "No  ", @"^3233(\d{6})", "", 0);
            ia[089] = new ApplicationIdentifiers("3234", "Longitud o primera dimensión, yardas (artículo comercial de medidas variables)                                                                ", "N4+N6       ", "LENGTH (yd)                                                           ", "No  ", @"^3234(\d{6})", "", 0);
            ia[090] = new ApplicationIdentifiers("3235", "Longitud o primera dimensión, yardas (artículo comercial de medidas variables)                                                                ", "N4+N6       ", "LENGTH (yd)                                                           ", "No  ", @"^3235(\d{6})", "", 0);
            ia[091] = new ApplicationIdentifiers("3240", "Ancho, diámetro, o segunda dimensión, pulgadas (artículo comercial de medidas variables)                                                      ", "N4+N6       ", "WIDTH (in)                                                            ", "No  ", @"^3240(\d{6})", "", 0);
            ia[092] = new ApplicationIdentifiers("3241", "Ancho, diámetro, o segunda dimensión, pulgadas (artículo comercial de medidas variables)                                                      ", "N4+N6       ", "WIDTH (in)                                                            ", "No  ", @"^3241(\d{6})", "", 0);
            ia[093] = new ApplicationIdentifiers("3242", "Ancho, diámetro, o segunda dimensión, pulgadas (artículo comercial de medidas variables)                                                      ", "N4+N6       ", "WIDTH (in)                                                            ", "No  ", @"^3242(\d{6})", "", 0);
            ia[094] = new ApplicationIdentifiers("3243", "Ancho, diámetro, o segunda dimensión, pulgadas (artículo comercial de medidas variables)                                                      ", "N4+N6       ", "WIDTH (in)                                                            ", "No  ", @"^3243(\d{6})", "", 0);
            ia[095] = new ApplicationIdentifiers("3244", "Ancho, diámetro, o segunda dimensión, pulgadas (artículo comercial de medidas variables)                                                      ", "N4+N6       ", "WIDTH (in)                                                            ", "No  ", @"^3244(\d{6})", "", 0);
            ia[096] = new ApplicationIdentifiers("3245", "Ancho, diámetro, o segunda dimensión, pulgadas (artículo comercial de medidas variables)                                                      ", "N4+N6       ", "WIDTH (in)                                                            ", "No  ", @"^3245(\d{6})", "", 0);
            ia[097] = new ApplicationIdentifiers("3250", "Ancho, diámetro, o segunda dimensión, pies (artículo comercial de medidas variables)                                                          ", "N4+N6       ", "WIDTH (ft)                                                            ", "No  ", @"^3250(\d{6})", "", 0);
            ia[098] = new ApplicationIdentifiers("3251", "Ancho, diámetro, o segunda dimensión, pies (artículo comercial de medidas variables)                                                          ", "N4+N6       ", "WIDTH (ft)                                                            ", "No  ", @"^3251(\d{6})", "", 0);
            ia[099] = new ApplicationIdentifiers("3252", "Ancho, diámetro, o segunda dimensión, pies (artículo comercial de medidas variables)                                                          ", "N4+N6       ", "WIDTH (ft)                                                            ", "No  ", @"^3252(\d{6})", "", 0);
            ia[100] = new ApplicationIdentifiers("3253", "Ancho, diámetro, o segunda dimensión, pies (artículo comercial de medidas variables)                                                          ", "N4+N6       ", "WIDTH (ft)                                                            ", "No  ", @"^3253(\d{6})", "", 0);
            ia[101] = new ApplicationIdentifiers("3254", "Ancho, diámetro, o segunda dimensión, pies (artículo comercial de medidas variables)                                                          ", "N4+N6       ", "WIDTH (ft)                                                            ", "No  ", @"^3254(\d{6})", "", 0);
            ia[102] = new ApplicationIdentifiers("3255", "Ancho, diámetro, o segunda dimensión, pies (artículo comercial de medidas variables)                                                          ", "N4+N6       ", "WIDTH (ft)                                                            ", "No  ", @"^3255(\d{6})", "", 0);
            ia[103] = new ApplicationIdentifiers("3260", "Ancho, diámetro, o segunda dimensión, yardas (artículo comercial de medidas variables)                                                        ", "N4+N6       ", "WIDTH (yd)                                                            ", "No  ", @"^3260(\d{6})", "", 0);
            ia[104] = new ApplicationIdentifiers("3261", "Ancho, diámetro, o segunda dimensión, yardas (artículo comercial de medidas variables)                                                        ", "N4+N6       ", "WIDTH (yd)                                                            ", "No  ", @"^3261(\d{6})", "", 0);
            ia[105] = new ApplicationIdentifiers("3262", "Ancho, diámetro, o segunda dimensión, yardas (artículo comercial de medidas variables)                                                        ", "N4+N6       ", "WIDTH (yd)                                                            ", "No  ", @"^3262(\d{6})", "", 0);
            ia[106] = new ApplicationIdentifiers("3263", "Ancho, diámetro, o segunda dimensión, yardas (artículo comercial de medidas variables)                                                        ", "N4+N6       ", "WIDTH (yd)                                                            ", "No  ", @"^3263(\d{6})", "", 0);
            ia[107] = new ApplicationIdentifiers("3264", "Ancho, diámetro, o segunda dimensión, yardas (artículo comercial de medidas variables)                                                        ", "N4+N6       ", "WIDTH (yd)                                                            ", "No  ", @"^3264(\d{6})", "", 0);
            ia[108] = new ApplicationIdentifiers("3265", "Ancho, diámetro, o segunda dimensión, yardas (artículo comercial de medidas variables)                                                        ", "N4+N6       ", "WIDTH (yd)                                                            ", "No  ", @"^3265(\d{6})", "", 0);
            ia[109] = new ApplicationIdentifiers("3270", "Profundidad, grosor, altura, o tercera dimensión, pulgadas (artículo comercial de medidas variables)                                          ", "N4+N6       ", "HEIGHT (in)                                                           ", "No  ", @"^3270(\d{6})", "", 0);
            ia[110] = new ApplicationIdentifiers("3271", "Profundidad, grosor, altura, o tercera dimensión, pulgadas (artículo comercial de medidas variables)                                          ", "N4+N6       ", "HEIGHT (in)                                                           ", "No  ", @"^3271(\d{6})", "", 0);
            ia[111] = new ApplicationIdentifiers("3272", "Profundidad, grosor, altura, o tercera dimensión, pulgadas (artículo comercial de medidas variables)                                          ", "N4+N6       ", "HEIGHT (in)                                                           ", "No  ", @"^3272(\d{6})", "", 0);
            ia[112] = new ApplicationIdentifiers("3273", "Profundidad, grosor, altura, o tercera dimensión, pulgadas (artículo comercial de medidas variables)                                          ", "N4+N6       ", "HEIGHT (in)                                                           ", "No  ", @"^3273(\d{6})", "", 0);
            ia[113] = new ApplicationIdentifiers("3274", "Profundidad, grosor, altura, o tercera dimensión, pulgadas (artículo comercial de medidas variables)                                          ", "N4+N6       ", "HEIGHT (in)                                                           ", "No  ", @"^3274(\d{6})", "", 0);
            ia[114] = new ApplicationIdentifiers("3275", "Profundidad, grosor, altura, o tercera dimensión, pulgadas (artículo comercial de medidas variables)                                          ", "N4+N6       ", "HEIGHT (in)                                                           ", "No  ", @"^3275(\d{6})", "", 0);
            ia[115] = new ApplicationIdentifiers("3280", "Profundidad, grosor, altura o tercera dimensión, pies (artículo comercial de medidas variables)                                               ", "N4+N6       ", "HEIGHT (ft)                                                           ", "No  ", @"^3280(\d{6})", "", 0);
            ia[116] = new ApplicationIdentifiers("3281", "Profundidad, grosor, altura o tercera dimensión, pies (artículo comercial de medidas variables)                                               ", "N4+N6       ", "HEIGHT (ft)                                                           ", "No  ", @"^3281(\d{6})", "", 0);
            ia[117] = new ApplicationIdentifiers("3282", "Profundidad, grosor, altura o tercera dimensión, pies (artículo comercial de medidas variables)                                               ", "N4+N6       ", "HEIGHT (ft)                                                           ", "No  ", @"^3282(\d{6})", "", 0);
            ia[118] = new ApplicationIdentifiers("3283", "Profundidad, grosor, altura o tercera dimensión, pies (artículo comercial de medidas variables)                                               ", "N4+N6       ", "HEIGHT (ft)                                                           ", "No  ", @"^3283(\d{6})", "", 0);
            ia[119] = new ApplicationIdentifiers("3284", "Profundidad, grosor, altura o tercera dimensión, pies (artículo comercial de medidas variables)                                               ", "N4+N6       ", "HEIGHT (ft)                                                           ", "No  ", @"^3284(\d{6})", "", 0);
            ia[120] = new ApplicationIdentifiers("3285", "Profundidad, grosor, altura o tercera dimensión, pies (artículo comercial de medidas variables)                                               ", "N4+N6       ", "HEIGHT (ft)                                                           ", "No  ", @"^3285(\d{6})", "", 0);
            ia[121] = new ApplicationIdentifiers("3290", "Profundidad, grosor, altura, o tercera dimensión, yardas (artículo comercial de medidas variables)                                            ", "N4+N6       ", "HEIGHT (yd)                                                           ", "No  ", @"^3290(\d{6})", "", 0);
            ia[122] = new ApplicationIdentifiers("3291", "Profundidad, grosor, altura, o tercera dimensión, yardas (artículo comercial de medidas variables)                                            ", "N4+N6       ", "HEIGHT (yd)                                                           ", "No  ", @"^3291(\d{6})", "", 0);
            ia[123] = new ApplicationIdentifiers("3292", "Profundidad, grosor, altura, o tercera dimensión, yardas (artículo comercial de medidas variables)                                            ", "N4+N6       ", "HEIGHT (yd)                                                           ", "No  ", @"^3292(\d{6})", "", 0);
            ia[124] = new ApplicationIdentifiers("3293", "Profundidad, grosor, altura, o tercera dimensión, yardas (artículo comercial de medidas variables)                                            ", "N4+N6       ", "HEIGHT (yd)                                                           ", "No  ", @"^3293(\d{6})", "", 0);
            ia[125] = new ApplicationIdentifiers("3294", "Profundidad, grosor, altura, o tercera dimensión, yardas (artículo comercial de medidas variables)                                            ", "N4+N6       ", "HEIGHT (yd)                                                           ", "No  ", @"^3294(\d{6})", "", 0);
            ia[126] = new ApplicationIdentifiers("3295", "Profundidad, grosor, altura, o tercera dimensión, yardas (artículo comercial de medidas variables)                                            ", "N4+N6       ", "HEIGHT (yd)                                                           ", "No  ", @"^3295(\d{6})", "", 0);
            ia[127] = new ApplicationIdentifiers("3300", "Peso logístico, kilogramos                                                                                                                    ", "N4+N6       ", "GROSS WEIGHT (kg)                                                     ", "No  ", @"^3300(\d{6})", "", 0);
            ia[128] = new ApplicationIdentifiers("3301", "Peso logístico, kilogramos                                                                                                                    ", "N4+N6       ", "GROSS WEIGHT (kg)                                                     ", "No  ", @"^3301(\d{6})", "", 0);
            ia[129] = new ApplicationIdentifiers("3302", "Peso logístico, kilogramos                                                                                                                    ", "N4+N6       ", "GROSS WEIGHT (kg)                                                     ", "No  ", @"^3302(\d{6})", "", 0);
            ia[130] = new ApplicationIdentifiers("3303", "Peso logístico, kilogramos                                                                                                                    ", "N4+N6       ", "GROSS WEIGHT (kg)                                                     ", "No  ", @"^3303(\d{6})", "", 0);
            ia[131] = new ApplicationIdentifiers("3304", "Peso logístico, kilogramos                                                                                                                    ", "N4+N6       ", "GROSS WEIGHT (kg)                                                     ", "No  ", @"^3304(\d{6})", "", 0);
            ia[132] = new ApplicationIdentifiers("3305", "Peso logístico, kilogramos                                                                                                                    ", "N4+N6       ", "GROSS WEIGHT (kg)                                                     ", "No  ", @"^3305(\d{6})", "", 0);
            ia[133] = new ApplicationIdentifiers("3310", "Longitud o primera dimensión, metros                                                                                                          ", "N4+N6       ", "LENGTH (m), log                                                       ", "No  ", @"^3310(\d{6})", "", 0);
            ia[134] = new ApplicationIdentifiers("3311", "Longitud o primera dimensión, metros                                                                                                          ", "N4+N6       ", "LENGTH (m), log                                                       ", "No  ", @"^3311(\d{6})", "", 0);
            ia[135] = new ApplicationIdentifiers("3312", "Longitud o primera dimensión, metros                                                                                                          ", "N4+N6       ", "LENGTH (m), log                                                       ", "No  ", @"^3312(\d{6})", "", 0);
            ia[136] = new ApplicationIdentifiers("3313", "Longitud o primera dimensión, metros                                                                                                          ", "N4+N6       ", "LENGTH (m), log                                                       ", "No  ", @"^3313(\d{6})", "", 0);
            ia[137] = new ApplicationIdentifiers("3314", "Longitud o primera dimensión, metros                                                                                                          ", "N4+N6       ", "LENGTH (m), log                                                       ", "No  ", @"^3314(\d{6})", "", 0);
            ia[138] = new ApplicationIdentifiers("3315", "Longitud o primera dimensión, metros                                                                                                          ", "N4+N6       ", "LENGTH (m), log                                                       ", "No  ", @"^3315(\d{6})", "", 0);
            ia[139] = new ApplicationIdentifiers("3320", "Ancho, diámetro, o segunda dimensión, metros                                                                                                  ", "N4+N6       ", "WIDTH (m), log                                                        ", "No  ", @"^3320(\d{6})", "", 0);
            ia[140] = new ApplicationIdentifiers("3321", "Ancho, diámetro, o segunda dimensión, metros                                                                                                  ", "N4+N6       ", "WIDTH (m), log                                                        ", "No  ", @"^3321(\d{6})", "", 0);
            ia[141] = new ApplicationIdentifiers("3322", "Ancho, diámetro, o segunda dimensión, metros                                                                                                  ", "N4+N6       ", "WIDTH (m), log                                                        ", "No  ", @"^3322(\d{6})", "", 0);
            ia[142] = new ApplicationIdentifiers("3323", "Ancho, diámetro, o segunda dimensión, metros                                                                                                  ", "N4+N6       ", "WIDTH (m), log                                                        ", "No  ", @"^3323(\d{6})", "", 0);
            ia[143] = new ApplicationIdentifiers("3324", "Ancho, diámetro, o segunda dimensión, metros                                                                                                  ", "N4+N6       ", "WIDTH (m), log                                                        ", "No  ", @"^3324(\d{6})", "", 0);
            ia[144] = new ApplicationIdentifiers("3325", "Ancho, diámetro, o segunda dimensión, metros                                                                                                  ", "N4+N6       ", "WIDTH (m), log                                                        ", "No  ", @"^3325(\d{6})", "", 0);
            ia[145] = new ApplicationIdentifiers("3330", "Profundidad, grosor, altura, o tercera dimensión, metros                                                                                      ", "N4+N6       ", "HEIGHT (m), log                                                       ", "No  ", @"^3330(\d{6})", "", 0);
            ia[146] = new ApplicationIdentifiers("3331", "Profundidad, grosor, altura, o tercera dimensión, metros                                                                                      ", "N4+N6       ", "HEIGHT (m), log                                                       ", "No  ", @"^3331(\d{6})", "", 0);
            ia[147] = new ApplicationIdentifiers("3332", "Profundidad, grosor, altura, o tercera dimensión, metros                                                                                      ", "N4+N6       ", "HEIGHT (m), log                                                       ", "No  ", @"^3332(\d{6})", "", 0);
            ia[148] = new ApplicationIdentifiers("3333", "Profundidad, grosor, altura, o tercera dimensión, metros                                                                                      ", "N4+N6       ", "HEIGHT (m), log                                                       ", "No  ", @"^3333(\d{6})", "", 0);
            ia[149] = new ApplicationIdentifiers("3334", "Profundidad, grosor, altura, o tercera dimensión, metros                                                                                      ", "N4+N6       ", "HEIGHT (m), log                                                       ", "No  ", @"^3334(\d{6})", "", 0);
            ia[150] = new ApplicationIdentifiers("3335", "Profundidad, grosor, altura, o tercera dimensión, metros                                                                                      ", "N4+N6       ", "HEIGHT (m), log                                                       ", "No  ", @"^3335(\d{6})", "", 0);
            ia[151] = new ApplicationIdentifiers("3340", "Área, metros cuadrados                                                                                                                        ", "N4+N6       ", "AREA (m2), log                                                        ", "No  ", @"^3340(\d{6})", "", 0);
            ia[152] = new ApplicationIdentifiers("3341", "Área, metros cuadrados                                                                                                                        ", "N4+N6       ", "AREA (m2), log                                                        ", "No  ", @"^3341(\d{6})", "", 0);
            ia[153] = new ApplicationIdentifiers("3342", "Área, metros cuadrados                                                                                                                        ", "N4+N6       ", "AREA (m2), log                                                        ", "No  ", @"^3342(\d{6})", "", 0);
            ia[154] = new ApplicationIdentifiers("3343", "Área, metros cuadrados                                                                                                                        ", "N4+N6       ", "AREA (m2), log                                                        ", "No  ", @"^3343(\d{6})", "", 0);
            ia[155] = new ApplicationIdentifiers("3344", "Área, metros cuadrados                                                                                                                        ", "N4+N6       ", "AREA (m2), log                                                        ", "No  ", @"^3344(\d{6})", "", 0);
            ia[156] = new ApplicationIdentifiers("3345", "Área, metros cuadrados                                                                                                                        ", "N4+N6       ", "AREA (m2), log                                                        ", "No  ", @"^3345(\d{6})", "", 0);
            ia[157] = new ApplicationIdentifiers("3350", "Volumen logístico, litros                                                                                                                     ", "N4+N6       ", "VOLUME (l), log                                                       ", "No  ", @"^3350(\d{6})", "", 0);
            ia[158] = new ApplicationIdentifiers("3351", "Volumen logístico, litros                                                                                                                     ", "N4+N6       ", "VOLUME (l), log                                                       ", "No  ", @"^3351(\d{6})", "", 0);
            ia[159] = new ApplicationIdentifiers("3352", "Volumen logístico, litros                                                                                                                     ", "N4+N6       ", "VOLUME (l), log                                                       ", "No  ", @"^3352(\d{6})", "", 0);
            ia[160] = new ApplicationIdentifiers("3353", "Volumen logístico, litros                                                                                                                     ", "N4+N6       ", "VOLUME (l), log                                                       ", "No  ", @"^3353(\d{6})", "", 0);
            ia[161] = new ApplicationIdentifiers("3354", "Volumen logístico, litros                                                                                                                     ", "N4+N6       ", "VOLUME (l), log                                                       ", "No  ", @"^3354(\d{6})", "", 0);
            ia[162] = new ApplicationIdentifiers("3355", "Volumen logístico, litros                                                                                                                     ", "N4+N6       ", "VOLUME (l), log                                                       ", "No  ", @"^3355(\d{6})", "", 0);
            ia[163] = new ApplicationIdentifiers("3360", "Volumen logístico, metros cúbicos                                                                                                             ", "N4+N6       ", "VOLUME (m3), log                                                      ", "No  ", @"^3360(\d{6})", "", 0);
            ia[164] = new ApplicationIdentifiers("3361", "Volumen logístico, metros cúbicos                                                                                                             ", "N4+N6       ", "VOLUME (m3), log                                                      ", "No  ", @"^3361(\d{6})", "", 0);
            ia[165] = new ApplicationIdentifiers("3362", "Volumen logístico, metros cúbicos                                                                                                             ", "N4+N6       ", "VOLUME (m3), log                                                      ", "No  ", @"^3362(\d{6})", "", 0);
            ia[166] = new ApplicationIdentifiers("3363", "Volumen logístico, metros cúbicos                                                                                                             ", "N4+N6       ", "VOLUME (m3), log                                                      ", "No  ", @"^3363(\d{6})", "", 0);
            ia[167] = new ApplicationIdentifiers("3364", "Volumen logístico, metros cúbicos                                                                                                             ", "N4+N6       ", "VOLUME (m3), log                                                      ", "No  ", @"^3364(\d{6})", "", 0);
            ia[168] = new ApplicationIdentifiers("3365", "Volumen logístico, metros cúbicos                                                                                                             ", "N4+N6       ", "VOLUME (m3), log                                                      ", "No  ", @"^3365(\d{6})", "", 0);
            ia[169] = new ApplicationIdentifiers("3370", "Kilogramos por metro cuadrado                                                                                                                 ", "N4+N6       ", "KG PER m2                                                             ", "No  ", @"^3370(\d{6})", "", 0);
            ia[170] = new ApplicationIdentifiers("3371", "Kilogramos por metro cuadrado                                                                                                                 ", "N4+N6       ", "KG PER m2                                                             ", "No  ", @"^3371(\d{6})", "", 0);
            ia[171] = new ApplicationIdentifiers("3372", "Kilogramos por metro cuadrado                                                                                                                 ", "N4+N6       ", "KG PER m2                                                             ", "No  ", @"^3372(\d{6})", "", 0);
            ia[172] = new ApplicationIdentifiers("3373", "Kilogramos por metro cuadrado                                                                                                                 ", "N4+N6       ", "KG PER m2                                                             ", "No  ", @"^3373(\d{6})", "", 0);
            ia[173] = new ApplicationIdentifiers("3374", "Kilogramos por metro cuadrado                                                                                                                 ", "N4+N6       ", "KG PER m2                                                             ", "No  ", @"^3374(\d{6})", "", 0);
            ia[174] = new ApplicationIdentifiers("3375", "Kilogramos por metro cuadrado                                                                                                                 ", "N4+N6       ", "KG PER m2                                                             ", "No  ", @"^3375(\d{6})", "", 0);
            ia[175] = new ApplicationIdentifiers("3400", "Peso logístico, libras                                                                                                                        ", "N4+N6       ", "GROSS WEIGHT (lb)                                                     ", "No  ", @"^3400(\d{6})", "", 0);
            ia[176] = new ApplicationIdentifiers("3401", "Peso logístico, libras                                                                                                                        ", "N4+N6       ", "GROSS WEIGHT (lb)                                                     ", "No  ", @"^3401(\d{6})", "", 0);
            ia[177] = new ApplicationIdentifiers("3402", "Peso logístico, libras                                                                                                                        ", "N4+N6       ", "GROSS WEIGHT (lb)                                                     ", "No  ", @"^3402(\d{6})", "", 0);
            ia[178] = new ApplicationIdentifiers("3403", "Peso logístico, libras                                                                                                                        ", "N4+N6       ", "GROSS WEIGHT (lb)                                                     ", "No  ", @"^3403(\d{6})", "", 0);
            ia[179] = new ApplicationIdentifiers("3404", "Peso logístico, libras                                                                                                                        ", "N4+N6       ", "GROSS WEIGHT (lb)                                                     ", "No  ", @"^3404(\d{6})", "", 0);
            ia[180] = new ApplicationIdentifiers("3405", "Peso logístico, libras                                                                                                                        ", "N4+N6       ", "GROSS WEIGHT (lb)                                                     ", "No  ", @"^3405(\d{6})", "", 0);
            ia[181] = new ApplicationIdentifiers("3410", "Longitud o primera dimensión, pulgadas                                                                                                        ", "N4+N6       ", "LENGTH (in), log                                                      ", "No  ", @"^3410(\d{6})", "", 0);
            ia[182] = new ApplicationIdentifiers("3411", "Longitud o primera dimensión, pulgadas                                                                                                        ", "N4+N6       ", "LENGTH (in), log                                                      ", "No  ", @"^3411(\d{6})", "", 0);
            ia[183] = new ApplicationIdentifiers("3412", "Longitud o primera dimensión, pulgadas                                                                                                        ", "N4+N6       ", "LENGTH (in), log                                                      ", "No  ", @"^3412(\d{6})", "", 0);
            ia[184] = new ApplicationIdentifiers("3413", "Longitud o primera dimensión, pulgadas                                                                                                        ", "N4+N6       ", "LENGTH (in), log                                                      ", "No  ", @"^3413(\d{6})", "", 0);
            ia[185] = new ApplicationIdentifiers("3414", "Longitud o primera dimensión, pulgadas                                                                                                        ", "N4+N6       ", "LENGTH (in), log                                                      ", "No  ", @"^3414(\d{6})", "", 0);
            ia[186] = new ApplicationIdentifiers("3415", "Longitud o primera dimensión, pulgadas                                                                                                        ", "N4+N6       ", "LENGTH (in), log                                                      ", "No  ", @"^3415(\d{6})", "", 0);
            ia[187] = new ApplicationIdentifiers("3420", "Longitud o primera dimensión, pies                                                                                                            ", "N4+N6       ", "LENGTH (ft), log                                                      ", "No  ", @"^3420(\d{6})", "", 0);
            ia[188] = new ApplicationIdentifiers("3421", "Longitud o primera dimensión, pies                                                                                                            ", "N4+N6       ", "LENGTH (ft), log                                                      ", "No  ", @"^3421(\d{6})", "", 0);
            ia[189] = new ApplicationIdentifiers("3422", "Longitud o primera dimensión, pies                                                                                                            ", "N4+N6       ", "LENGTH (ft), log                                                      ", "No  ", @"^3422(\d{6})", "", 0);
            ia[190] = new ApplicationIdentifiers("3423", "Longitud o primera dimensión, pies                                                                                                            ", "N4+N6       ", "LENGTH (ft), log                                                      ", "No  ", @"^3423(\d{6})", "", 0);
            ia[191] = new ApplicationIdentifiers("3424", "Longitud o primera dimensión, pies                                                                                                            ", "N4+N6       ", "LENGTH (ft), log                                                      ", "No  ", @"^3424(\d{6})", "", 0);
            ia[192] = new ApplicationIdentifiers("3425", "Longitud o primera dimensión, pies                                                                                                            ", "N4+N6       ", "LENGTH (ft), log                                                      ", "No  ", @"^3425(\d{6})", "", 0);
            ia[193] = new ApplicationIdentifiers("3430", "Longitud o primera dimensión, yardas                                                                                                          ", "N4+N6       ", "LENGTH (yd), log                                                      ", "No  ", @"^3430(\d{6})", "", 0);
            ia[194] = new ApplicationIdentifiers("3431", "Longitud o primera dimensión, yardas                                                                                                          ", "N4+N6       ", "LENGTH (yd), log                                                      ", "No  ", @"^3431(\d{6})", "", 0);
            ia[195] = new ApplicationIdentifiers("3432", "Longitud o primera dimensión, yardas                                                                                                          ", "N4+N6       ", "LENGTH (yd), log                                                      ", "No  ", @"^3432(\d{6})", "", 0);
            ia[196] = new ApplicationIdentifiers("3433", "Longitud o primera dimensión, yardas                                                                                                          ", "N4+N6       ", "LENGTH (yd), log                                                      ", "No  ", @"^3433(\d{6})", "", 0);
            ia[197] = new ApplicationIdentifiers("3434", "Longitud o primera dimensión, yardas                                                                                                          ", "N4+N6       ", "LENGTH (yd), log                                                      ", "No  ", @"^3434(\d{6})", "", 0);
            ia[198] = new ApplicationIdentifiers("3435", "Longitud o primera dimensión, yardas                                                                                                          ", "N4+N6       ", "LENGTH (yd), log                                                      ", "No  ", @"^3435(\d{6})", "", 0);
            ia[199] = new ApplicationIdentifiers("3440", "Ancho, diámetro, o segunda dimensión, pulgadas                                                                                                ", "N4+N6       ", "WIDTH (in), log                                                       ", "No  ", @"^3440(\d{6})", "", 0);
            ia[200] = new ApplicationIdentifiers("3441", "Ancho, diámetro, o segunda dimensión, pulgadas                                                                                                ", "N4+N6       ", "WIDTH (in), log                                                       ", "No  ", @"^3441(\d{6})", "", 0);
            ia[201] = new ApplicationIdentifiers("3442", "Ancho, diámetro, o segunda dimensión, pulgadas                                                                                                ", "N4+N6       ", "WIDTH (in), log                                                       ", "No  ", @"^3442(\d{6})", "", 0);
            ia[202] = new ApplicationIdentifiers("3443", "Ancho, diámetro, o segunda dimensión, pulgadas                                                                                                ", "N4+N6       ", "WIDTH (in), log                                                       ", "No  ", @"^3443(\d{6})", "", 0);
            ia[203] = new ApplicationIdentifiers("3444", "Ancho, diámetro, o segunda dimensión, pulgadas                                                                                                ", "N4+N6       ", "WIDTH (in), log                                                       ", "No  ", @"^3444(\d{6})", "", 0);
            ia[204] = new ApplicationIdentifiers("3445", "Ancho, diámetro, o segunda dimensión, pulgadas                                                                                                ", "N4+N6       ", "WIDTH (in), log                                                       ", "No  ", @"^3445(\d{6})", "", 0);
            ia[205] = new ApplicationIdentifiers("3450", "Ancho, diámetro, o segunda dimensión, pies                                                                                                    ", "N4+N6       ", "WIDTH (ft), log                                                       ", "No  ", @"^3450(\d{6})", "", 0);
            ia[207] = new ApplicationIdentifiers("3452", "Ancho, diámetro, o segunda dimensión, pies                                                                                                    ", "N4+N6       ", "WIDTH (ft), log                                                       ", "No  ", @"^3452(\d{6})", "", 0);
            ia[206] = new ApplicationIdentifiers("3451", "Ancho, diámetro, o segunda dimensión, pies                                                                                                    ", "N4+N6       ", "WIDTH (ft), log                                                       ", "No  ", @"^3451(\d{6})", "", 0);
            ia[208] = new ApplicationIdentifiers("3453", "Ancho, diámetro, o segunda dimensión, pies                                                                                                    ", "N4+N6       ", "WIDTH (ft), log                                                       ", "No  ", @"^3453(\d{6})", "", 0);
            ia[209] = new ApplicationIdentifiers("3454", "Ancho, diámetro, o segunda dimensión, pies                                                                                                    ", "N4+N6       ", "WIDTH (ft), log                                                       ", "No  ", @"^3454(\d{6})", "", 0);
            ia[210] = new ApplicationIdentifiers("3455", "Ancho, diámetro, o segunda dimensión, pies                                                                                                    ", "N4+N6       ", "WIDTH (ft), log                                                       ", "No  ", @"^3455(\d{6})", "", 0);
            ia[211] = new ApplicationIdentifiers("3460", "Ancho, diámetro, o segunda dimensión, yardas                                                                                                  ", "N4+N6       ", "WIDTH (yd), log                                                       ", "No  ", @"^3460(\d{6})", "", 0);
            ia[212] = new ApplicationIdentifiers("3461", "Ancho, diámetro, o segunda dimensión, yardas                                                                                                  ", "N4+N6       ", "WIDTH (yd), log                                                       ", "No  ", @"^3461(\d{6})", "", 0);
            ia[213] = new ApplicationIdentifiers("3462", "Ancho, diámetro, o segunda dimensión, yardas                                                                                                  ", "N4+N6       ", "WIDTH (yd), log                                                       ", "No  ", @"^3462(\d{6})", "", 0);
            ia[214] = new ApplicationIdentifiers("3463", "Ancho, diámetro, o segunda dimensión, yardas                                                                                                  ", "N4+N6       ", "WIDTH (yd), log                                                       ", "No  ", @"^3463(\d{6})", "", 0);
            ia[215] = new ApplicationIdentifiers("3464", "Ancho, diámetro, o segunda dimensión, yardas                                                                                                  ", "N4+N6       ", "WIDTH (yd), log                                                       ", "No  ", @"^3464(\d{6})", "", 0);
            ia[216] = new ApplicationIdentifiers("3465", "Ancho, diámetro, o segunda dimensión, yardas                                                                                                  ", "N4+N6       ", "WIDTH (yd), log                                                       ", "No  ", @"^3465(\d{6})", "", 0);
            ia[217] = new ApplicationIdentifiers("3470", "Profundidad, grosor, altura, o tercera dimensión, pulgadas                                                                                    ", "N4+N6       ", "HEIGHT (in), log                                                      ", "No  ", @"^3470(\d{6})", "", 0);
            ia[218] = new ApplicationIdentifiers("3471", "Profundidad, grosor, altura, o tercera dimensión, pulgadas                                                                                    ", "N4+N6       ", "HEIGHT (in), log                                                      ", "No  ", @"^3471(\d{6})", "", 0);
            ia[219] = new ApplicationIdentifiers("3472", "Profundidad, grosor, altura, o tercera dimensión, pulgadas                                                                                    ", "N4+N6       ", "HEIGHT (in), log                                                      ", "No  ", @"^3472(\d{6})", "", 0);
            ia[220] = new ApplicationIdentifiers("3473", "Profundidad, grosor, altura, o tercera dimensión, pulgadas                                                                                    ", "N4+N6       ", "HEIGHT (in), log                                                      ", "No  ", @"^3473(\d{6})", "", 0);
            ia[221] = new ApplicationIdentifiers("3474", "Profundidad, grosor, altura, o tercera dimensión, pulgadas                                                                                    ", "N4+N6       ", "HEIGHT (in), log                                                      ", "No  ", @"^3474(\d{6})", "", 0);
            ia[222] = new ApplicationIdentifiers("3475", "Profundidad, grosor, altura, o tercera dimensión, pulgadas                                                                                    ", "N4+N6       ", "HEIGHT (in), log                                                      ", "No  ", @"^3475(\d{6})", "", 0);
            ia[223] = new ApplicationIdentifiers("3480", "Profundidad, grosor, altura o tercera dimensión, pies                                                                                         ", "N4+N6       ", "HEIGHT (ft), log                                                      ", "No  ", @"^3480(\d{6})", "", 0);
            ia[224] = new ApplicationIdentifiers("3481", "Profundidad, grosor, altura o tercera dimensión, pies                                                                                         ", "N4+N6       ", "HEIGHT (ft), log                                                      ", "No  ", @"^3481(\d{6})", "", 0);
            ia[225] = new ApplicationIdentifiers("3482", "Profundidad, grosor, altura o tercera dimensión, pies                                                                                         ", "N4+N6       ", "HEIGHT (ft), log                                                      ", "No  ", @"^3482(\d{6})", "", 0);
            ia[226] = new ApplicationIdentifiers("3483", "Profundidad, grosor, altura o tercera dimensión, pies                                                                                         ", "N4+N6       ", "HEIGHT (ft), log                                                      ", "No  ", @"^3483(\d{6})", "", 0);
            ia[227] = new ApplicationIdentifiers("3484", "Profundidad, grosor, altura o tercera dimensión, pies                                                                                         ", "N4+N6       ", "HEIGHT (ft), log                                                      ", "No  ", @"^3484(\d{6})", "", 0);
            ia[228] = new ApplicationIdentifiers("3485", "Profundidad, grosor, altura o tercera dimensión, pies                                                                                         ", "N4+N6       ", "HEIGHT (ft), log                                                      ", "No  ", @"^3485(\d{6})", "", 0);
            ia[229] = new ApplicationIdentifiers("3490", "Profundidad, grosor, altura, o tercera dimensión, yardas                                                                                      ", "N4+N6       ", "HEIGHT (yd), log                                                      ", "No  ", @"^3490(\d{6})", "", 0);
            ia[230] = new ApplicationIdentifiers("3491", "Profundidad, grosor, altura, o tercera dimensión, yardas                                                                                      ", "N4+N6       ", "HEIGHT (yd), log                                                      ", "No  ", @"^3491(\d{6})", "", 0);
            ia[231] = new ApplicationIdentifiers("3492", "Profundidad, grosor, altura, o tercera dimensión, yardas                                                                                      ", "N4+N6       ", "HEIGHT (yd), log                                                      ", "No  ", @"^3492(\d{6})", "", 0);
            ia[232] = new ApplicationIdentifiers("3493", "Profundidad, grosor, altura, o tercera dimensión, yardas                                                                                      ", "N4+N6       ", "HEIGHT (yd), log                                                      ", "No  ", @"^3493(\d{6})", "", 0);
            ia[233] = new ApplicationIdentifiers("3494", "Profundidad, grosor, altura, o tercera dimensión, yardas                                                                                      ", "N4+N6       ", "HEIGHT (yd), log                                                      ", "No  ", @"^3494(\d{6})", "", 0);
            ia[234] = new ApplicationIdentifiers("3495", "Profundidad, grosor, altura, o tercera dimensión, yardas                                                                                      ", "N4+N6       ", "HEIGHT (yd), log                                                      ", "No  ", @"^3495(\d{6})", "", 0);
            ia[235] = new ApplicationIdentifiers("3500", "Área, pulgadas cuadradas (artículo comercial de medidas variables)                                                                            ", "N4+N6       ", "AREA (in2)                                                            ", "No  ", @"^3500(\d{6})", "", 0);
            ia[236] = new ApplicationIdentifiers("3501", "Área, pulgadas cuadradas (artículo comercial de medidas variables)                                                                            ", "N4+N6       ", "AREA (in2)                                                            ", "No  ", @"^3501(\d{6})", "", 0);
            ia[237] = new ApplicationIdentifiers("3502", "Área, pulgadas cuadradas (artículo comercial de medidas variables)                                                                            ", "N4+N6       ", "AREA (in2)                                                            ", "No  ", @"^3502(\d{6})", "", 0);
            ia[238] = new ApplicationIdentifiers("3503", "Área, pulgadas cuadradas (artículo comercial de medidas variables)                                                                            ", "N4+N6       ", "AREA (in2)                                                            ", "No  ", @"^3503(\d{6})", "", 0);
            ia[239] = new ApplicationIdentifiers("3504", "Área, pulgadas cuadradas (artículo comercial de medidas variables)                                                                            ", "N4+N6       ", "AREA (in2)                                                            ", "No  ", @"^3504(\d{6})", "", 0);
            ia[240] = new ApplicationIdentifiers("3505", "Área, pulgadas cuadradas (artículo comercial de medidas variables)                                                                            ", "N4+N6       ", "AREA (in2)                                                            ", "No  ", @"^3505(\d{6})", "", 0);
            ia[241] = new ApplicationIdentifiers("3510", "Área, pies cuadrados (artículo comercial de medidas variables)                                                                                ", "N4+N6       ", "AREA (ft2)                                                            ", "No  ", @"^3510(\d{6})", "", 0);
            ia[242] = new ApplicationIdentifiers("3511", "Área, pies cuadrados (artículo comercial de medidas variables)                                                                                ", "N4+N6       ", "AREA (ft2)                                                            ", "No  ", @"^3511(\d{6})", "", 0);
            ia[243] = new ApplicationIdentifiers("3512", "Área, pies cuadrados (artículo comercial de medidas variables)                                                                                ", "N4+N6       ", "AREA (ft2)                                                            ", "No  ", @"^3512(\d{6})", "", 0);
            ia[244] = new ApplicationIdentifiers("3513", "Área, pies cuadrados (artículo comercial de medidas variables)                                                                                ", "N4+N6       ", "AREA (ft2)                                                            ", "No  ", @"^3513(\d{6})", "", 0);
            ia[245] = new ApplicationIdentifiers("3514", "Área, pies cuadrados (artículo comercial de medidas variables)                                                                                ", "N4+N6       ", "AREA (ft2)                                                            ", "No  ", @"^3514(\d{6})", "", 0);
            ia[246] = new ApplicationIdentifiers("3515", "Área, pies cuadrados (artículo comercial de medidas variables)                                                                                ", "N4+N6       ", "AREA (ft2)                                                            ", "No  ", @"^3515(\d{6})", "", 0);
            ia[247] = new ApplicationIdentifiers("3520", "Área, yardas cuadradas (artículo comercial de medidas variables)                                                                              ", "N4+N6       ", "AREA (yd2)                                                            ", "No  ", @"^3520(\d{6})", "", 0);
            ia[248] = new ApplicationIdentifiers("3521", "Área, yardas cuadradas (artículo comercial de medidas variables)                                                                              ", "N4+N6       ", "AREA (yd2)                                                            ", "No  ", @"^3521(\d{6})", "", 0);
            ia[249] = new ApplicationIdentifiers("3522", "Área, yardas cuadradas (artículo comercial de medidas variables)                                                                              ", "N4+N6       ", "AREA (yd2)                                                            ", "No  ", @"^3522(\d{6})", "", 0);
            ia[250] = new ApplicationIdentifiers("3523", "Área, yardas cuadradas (artículo comercial de medidas variables)                                                                              ", "N4+N6       ", "AREA (yd2)                                                            ", "No  ", @"^3523(\d{6})", "", 0);
            ia[251] = new ApplicationIdentifiers("3524", "Área, yardas cuadradas (artículo comercial de medidas variables)                                                                              ", "N4+N6       ", "AREA (yd2)                                                            ", "No  ", @"^3524(\d{6})", "", 0);
            ia[252] = new ApplicationIdentifiers("3525", "Área, yardas cuadradas (artículo comercial de medidas variables)                                                                              ", "N4+N6       ", "AREA (yd2)                                                            ", "No  ", @"^3525(\d{6})", "", 0);
            ia[253] = new ApplicationIdentifiers("3530", "Área, pulgadas cuadradas                                                                                                                      ", "N4+N6       ", "AREA (in2), log                                                       ", "No  ", @"^3530(\d{6})", "", 0);
            ia[254] = new ApplicationIdentifiers("3531", "Área, pulgadas cuadradas                                                                                                                      ", "N4+N6       ", "AREA (in2), log                                                       ", "No  ", @"^3531(\d{6})", "", 0);
            ia[255] = new ApplicationIdentifiers("3532", "Área, pulgadas cuadradas                                                                                                                      ", "N4+N6       ", "AREA (in2), log                                                       ", "No  ", @"^3532(\d{6})", "", 0);
            ia[256] = new ApplicationIdentifiers("3533", "Área, pulgadas cuadradas                                                                                                                      ", "N4+N6       ", "AREA (in2), log                                                       ", "No  ", @"^3533(\d{6})", "", 0);
            ia[257] = new ApplicationIdentifiers("3534", "Área, pulgadas cuadradas                                                                                                                      ", "N4+N6       ", "AREA (in2), log                                                       ", "No  ", @"^3534(\d{6})", "", 0);
            ia[258] = new ApplicationIdentifiers("3535", "Área, pulgadas cuadradas                                                                                                                      ", "N4+N6       ", "AREA (in2), log                                                       ", "No  ", @"^3535(\d{6})", "", 0);
            ia[259] = new ApplicationIdentifiers("3540", "Área, pies cuadrados                                                                                                                          ", "N4+N6       ", "AREA (ft2), log                                                       ", "No  ", @"^3540(\d{6})", "", 0);
            ia[260] = new ApplicationIdentifiers("3541", "Área, pies cuadrados                                                                                                                          ", "N4+N6       ", "AREA (ft2), log                                                       ", "No  ", @"^3541(\d{6})", "", 0);
            ia[261] = new ApplicationIdentifiers("3542", "Área, pies cuadrados                                                                                                                          ", "N4+N6       ", "AREA (ft2), log                                                       ", "No  ", @"^3542(\d{6})", "", 0);
            ia[262] = new ApplicationIdentifiers("3543", "Área, pies cuadrados                                                                                                                          ", "N4+N6       ", "AREA (ft2), log                                                       ", "No  ", @"^3543(\d{6})", "", 0);
            ia[263] = new ApplicationIdentifiers("3544", "Área, pies cuadrados                                                                                                                          ", "N4+N6       ", "AREA (ft2), log                                                       ", "No  ", @"^3544(\d{6})", "", 0);
            ia[264] = new ApplicationIdentifiers("3545", "Área, pies cuadrados                                                                                                                          ", "N4+N6       ", "AREA (ft2), log                                                       ", "No  ", @"^3545(\d{6})", "", 0);
            ia[265] = new ApplicationIdentifiers("3550", "Área, yardas cuadradas                                                                                                                        ", "N4+N6       ", "AREA (yd2), log                                                       ", "No  ", @"^3550(\d{6})", "", 0);
            ia[266] = new ApplicationIdentifiers("3551", "Área, yardas cuadradas                                                                                                                        ", "N4+N6       ", "AREA (yd2), log                                                       ", "No  ", @"^3551(\d{6})", "", 0);
            ia[267] = new ApplicationIdentifiers("3552", "Área, yardas cuadradas                                                                                                                        ", "N4+N6       ", "AREA (yd2), log                                                       ", "No  ", @"^3552(\d{6})", "", 0);
            ia[268] = new ApplicationIdentifiers("3553", "Área, yardas cuadradas                                                                                                                        ", "N4+N6       ", "AREA (yd2), log                                                       ", "No  ", @"^3553(\d{6})", "", 0);
            ia[269] = new ApplicationIdentifiers("3554", "Área, yardas cuadradas                                                                                                                        ", "N4+N6       ", "AREA (yd2), log                                                       ", "No  ", @"^3554(\d{6})", "", 0);
            ia[270] = new ApplicationIdentifiers("3555", "Área, yardas cuadradas                                                                                                                        ", "N4+N6       ", "AREA (yd2), log                                                       ", "No  ", @"^3555(\d{6})", "", 0);
            ia[271] = new ApplicationIdentifiers("3560", "Peso neto, onzas troy (artículo comercial de medidas variables)                                                                               ", "N4+N6       ", "NET WEIGHT (t oz)                                                     ", "No  ", @"^3560(\d{6})", "", 0);
            ia[272] = new ApplicationIdentifiers("3561", "Peso neto, onzas troy (artículo comercial de medidas variables)                                                                               ", "N4+N6       ", "NET WEIGHT (t oz)                                                     ", "No  ", @"^3561(\d{6})", "", 0);
            ia[273] = new ApplicationIdentifiers("3562", "Peso neto, onzas troy (artículo comercial de medidas variables)                                                                               ", "N4+N6       ", "NET WEIGHT (t oz)                                                     ", "No  ", @"^3562(\d{6})", "", 0);
            ia[274] = new ApplicationIdentifiers("3563", "Peso neto, onzas troy (artículo comercial de medidas variables)                                                                               ", "N4+N6       ", "NET WEIGHT (t oz)                                                     ", "No  ", @"^3563(\d{6})", "", 0);
            ia[275] = new ApplicationIdentifiers("3564", "Peso neto, onzas troy (artículo comercial de medidas variables)                                                                               ", "N4+N6       ", "NET WEIGHT (t oz)                                                     ", "No  ", @"^3564(\d{6})", "", 0);
            ia[276] = new ApplicationIdentifiers("3565", "Peso neto, onzas troy (artículo comercial de medidas variables)                                                                               ", "N4+N6       ", "NET WEIGHT (t oz)                                                     ", "No  ", @"^3565(\d{6})", "", 0);
            ia[277] = new ApplicationIdentifiers("3570", "Peso neto (o volumen), onzas (artículo comercial de medidas variables)                                                                        ", "N4+N6       ", "NET VOLUME (oz)                                                       ", "No  ", @"^3570(\d{6})", "", 0);
            ia[278] = new ApplicationIdentifiers("3571", "Peso neto (o volumen), onzas (artículo comercial de medidas variables)                                                                        ", "N4+N6       ", "NET VOLUME (oz)                                                       ", "No  ", @"^3571(\d{6})", "", 0);
            ia[279] = new ApplicationIdentifiers("3572", "Peso neto (o volumen), onzas (artículo comercial de medidas variables)                                                                        ", "N4+N6       ", "NET VOLUME (oz)                                                       ", "No  ", @"^3572(\d{6})", "", 0);
            ia[280] = new ApplicationIdentifiers("3573", "Peso neto (o volumen), onzas (artículo comercial de medidas variables)                                                                        ", "N4+N6       ", "NET VOLUME (oz)                                                       ", "No  ", @"^3573(\d{6})", "", 0);
            ia[281] = new ApplicationIdentifiers("3574", "Peso neto (o volumen), onzas (artículo comercial de medidas variables)                                                                        ", "N4+N6       ", "NET VOLUME (oz)                                                       ", "No  ", @"^3574(\d{6})", "", 0);
            ia[282] = new ApplicationIdentifiers("3575", "Peso neto (o volumen), onzas (artículo comercial de medidas variables)                                                                        ", "N4+N6       ", "NET VOLUME (oz)                                                       ", "No  ", @"^3575(\d{6})", "", 0);
            ia[283] = new ApplicationIdentifiers("3600", "Volumen neto, cuartos (artículo comercial de medidas variables)                                                                               ", "N4+N6       ", "NET VOLUME (qt)                                                       ", "No  ", @"^3600(\d{6})", "", 0);
            ia[284] = new ApplicationIdentifiers("3601", "Volumen neto, cuartos (artículo comercial de medidas variables)                                                                               ", "N4+N6       ", "NET VOLUME (qt)                                                       ", "No  ", @"^3601(\d{6})", "", 0);
            ia[285] = new ApplicationIdentifiers("3602", "Volumen neto, cuartos (artículo comercial de medidas variables)                                                                               ", "N4+N6       ", "NET VOLUME (qt)                                                       ", "No  ", @"^3602(\d{6})", "", 0);
            ia[286] = new ApplicationIdentifiers("3603", "Volumen neto, cuartos (artículo comercial de medidas variables)                                                                               ", "N4+N6       ", "NET VOLUME (qt)                                                       ", "No  ", @"^3603(\d{6})", "", 0);
            ia[287] = new ApplicationIdentifiers("3604", "Volumen neto, cuartos (artículo comercial de medidas variables)                                                                               ", "N4+N6       ", "NET VOLUME (qt)                                                       ", "No  ", @"^3604(\d{6})", "", 0);
            ia[288] = new ApplicationIdentifiers("3605", "Volumen neto, cuartos (artículo comercial de medidas variables)                                                                               ", "N4+N6       ", "NET VOLUME (qt)                                                       ", "No  ", @"^3605(\d{6})", "", 0);
            ia[289] = new ApplicationIdentifiers("3610", "Volumen neto, galones estadounidenses (artículo comercial de medidas variables)                                                               ", "N4+N6       ", "NET VOLUME (gal.)                                                     ", "No  ", @"^3610(\d{6})", "", 0);
            ia[290] = new ApplicationIdentifiers("3611", "Volumen neto, galones estadounidenses (artículo comercial de medidas variables)                                                               ", "N4+N6       ", "NET VOLUME (gal.)                                                     ", "No  ", @"^3611(\d{6})", "", 0);
            ia[291] = new ApplicationIdentifiers("3612", "Volumen neto, galones estadounidenses (artículo comercial de medidas variables)                                                               ", "N4+N6       ", "NET VOLUME (gal.)                                                     ", "No  ", @"^3612(\d{6})", "", 0);
            ia[292] = new ApplicationIdentifiers("3613", "Volumen neto, galones estadounidenses (artículo comercial de medidas variables)                                                               ", "N4+N6       ", "NET VOLUME (gal.)                                                     ", "No  ", @"^3613(\d{6})", "", 0);
            ia[293] = new ApplicationIdentifiers("3614", "Volumen neto, galones estadounidenses (artículo comercial de medidas variables)                                                               ", "N4+N6       ", "NET VOLUME (gal.)                                                     ", "No  ", @"^3614(\d{6})", "", 0);
            ia[294] = new ApplicationIdentifiers("3615", "Volumen neto, galones estadounidenses (artículo comercial de medidas variables)                                                               ", "N4+N6       ", "NET VOLUME (gal.)                                                     ", "No  ", @"^3615(\d{6})", "", 0);
            ia[295] = new ApplicationIdentifiers("3620", "Volumen logístico, cuartos                                                                                                                    ", "N4+N6       ", "VOLUME (qt), log                                                      ", "No  ", @"^3620(\d{6})", "", 0);
            ia[296] = new ApplicationIdentifiers("3621", "Volumen logístico, cuartos                                                                                                                    ", "N4+N6       ", "VOLUME (qt), log                                                      ", "No  ", @"^3621(\d{6})", "", 0);
            ia[297] = new ApplicationIdentifiers("3622", "Volumen logístico, cuartos                                                                                                                    ", "N4+N6       ", "VOLUME (qt), log                                                      ", "No  ", @"^3622(\d{6})", "", 0);
            ia[298] = new ApplicationIdentifiers("3623", "Volumen logístico, cuartos                                                                                                                    ", "N4+N6       ", "VOLUME (qt), log                                                      ", "No  ", @"^3623(\d{6})", "", 0);
            ia[299] = new ApplicationIdentifiers("3624", "Volumen logístico, cuartos                                                                                                                    ", "N4+N6       ", "VOLUME (qt), log                                                      ", "No  ", @"^3624(\d{6})", "", 0);
            ia[300] = new ApplicationIdentifiers("3625", "Volumen logístico, cuartos                                                                                                                    ", "N4+N6       ", "VOLUME (qt), log                                                      ", "No  ", @"^3625(\d{6})", "", 0);
            ia[301] = new ApplicationIdentifiers("3630", "Volumen logístico, galones estadounidenses                                                                                                    ", "N4+N6       ", "VOLUME (gal.), log                                                    ", "No  ", @"^3630(\d{6})", "", 0);
            ia[302] = new ApplicationIdentifiers("3631", "Volumen logístico, galones estadounidenses                                                                                                    ", "N4+N6       ", "VOLUME (gal.), log                                                    ", "No  ", @"^3631(\d{6})", "", 0);
            ia[303] = new ApplicationIdentifiers("3632", "Volumen logístico, galones estadounidenses                                                                                                    ", "N4+N6       ", "VOLUME (gal.), log                                                    ", "No  ", @"^3632(\d{6})", "", 0);
            ia[304] = new ApplicationIdentifiers("3633", "Volumen logístico, galones estadounidenses                                                                                                    ", "N4+N6       ", "VOLUME (gal.), log                                                    ", "No  ", @"^3633(\d{6})", "", 0);
            ia[305] = new ApplicationIdentifiers("3634", "Volumen logístico, galones estadounidenses                                                                                                    ", "N4+N6       ", "VOLUME (gal.), log                                                    ", "No  ", @"^3634(\d{6})", "", 0);
            ia[306] = new ApplicationIdentifiers("3635", "Volumen logístico, galones estadounidenses                                                                                                    ", "N4+N6       ", "VOLUME (gal.), log                                                    ", "No  ", @"^3635(\d{6})", "", 0);
            ia[307] = new ApplicationIdentifiers("3640", "Volumen neto, pulgadas cúbicas (artículo comercial de medidas variables)                                                                      ", "N4+N6       ", "VOLUME (in3)                                                          ", "No  ", @"^3640(\d{6})", "", 0);
            ia[308] = new ApplicationIdentifiers("3641", "Volumen neto, pulgadas cúbicas (artículo comercial de medidas variables)                                                                      ", "N4+N6       ", "VOLUME (in3)                                                          ", "No  ", @"^3641(\d{6})", "", 0);
            ia[309] = new ApplicationIdentifiers("3642", "Volumen neto, pulgadas cúbicas (artículo comercial de medidas variables)                                                                      ", "N4+N6       ", "VOLUME (in3)                                                          ", "No  ", @"^3642(\d{6})", "", 0);
            ia[310] = new ApplicationIdentifiers("3643", "Volumen neto, pulgadas cúbicas (artículo comercial de medidas variables)                                                                      ", "N4+N6       ", "VOLUME (in3)                                                          ", "No  ", @"^3643(\d{6})", "", 0);
            ia[311] = new ApplicationIdentifiers("3644", "Volumen neto, pulgadas cúbicas (artículo comercial de medidas variables)                                                                      ", "N4+N6       ", "VOLUME (in3)                                                          ", "No  ", @"^3644(\d{6})", "", 0);
            ia[312] = new ApplicationIdentifiers("3645", "Volumen neto, pulgadas cúbicas (artículo comercial de medidas variables)                                                                      ", "N4+N6       ", "VOLUME (in3)                                                          ", "No  ", @"^3645(\d{6})", "", 0);
            ia[313] = new ApplicationIdentifiers("3650", "Volumen neto, pies cúbicos (artículo comercial de medidas variables)                                                                          ", "N4+N6       ", "VOLUME (ft3)                                                          ", "No  ", @"^3650(\d{6})", "", 0);
            ia[314] = new ApplicationIdentifiers("3651", "Volumen neto, pies cúbicos (artículo comercial de medidas variables)                                                                          ", "N4+N6       ", "VOLUME (ft3)                                                          ", "No  ", @"^3651(\d{6})", "", 0);
            ia[315] = new ApplicationIdentifiers("3652", "Volumen neto, pies cúbicos (artículo comercial de medidas variables)                                                                          ", "N4+N6       ", "VOLUME (ft3)                                                          ", "No  ", @"^3652(\d{6})", "", 0);
            ia[316] = new ApplicationIdentifiers("3653", "Volumen neto, pies cúbicos (artículo comercial de medidas variables)                                                                          ", "N4+N6       ", "VOLUME (ft3)                                                          ", "No  ", @"^3653(\d{6})", "", 0);
            ia[317] = new ApplicationIdentifiers("3654", "Volumen neto, pies cúbicos (artículo comercial de medidas variables)                                                                          ", "N4+N6       ", "VOLUME (ft3)                                                          ", "No  ", @"^3654(\d{6})", "", 0);
            ia[318] = new ApplicationIdentifiers("3655", "Volumen neto, pies cúbicos (artículo comercial de medidas variables)                                                                          ", "N4+N6       ", "VOLUME (ft3)                                                          ", "No  ", @"^3655(\d{6})", "", 0);
            ia[319] = new ApplicationIdentifiers("3660", "Volumen neto, yardas cúbicas (artículo comercial de medidas variables)                                                                        ", "N4+N6       ", "VOLUME (yd3)                                                          ", "No  ", @"^3660(\d{6})", "", 0);
            ia[320] = new ApplicationIdentifiers("3661", "Volumen neto, yardas cúbicas (artículo comercial de medidas variables)                                                                        ", "N4+N6       ", "VOLUME (yd3)                                                          ", "No  ", @"^3661(\d{6})", "", 0);
            ia[321] = new ApplicationIdentifiers("3662", "Volumen neto, yardas cúbicas (artículo comercial de medidas variables)                                                                        ", "N4+N6       ", "VOLUME (yd3)                                                          ", "No  ", @"^3662(\d{6})", "", 0);
            ia[322] = new ApplicationIdentifiers("3663", "Volumen neto, yardas cúbicas (artículo comercial de medidas variables)                                                                        ", "N4+N6       ", "VOLUME (yd3)                                                          ", "No  ", @"^3663(\d{6})", "", 0);
            ia[323] = new ApplicationIdentifiers("3664", "Volumen neto, yardas cúbicas (artículo comercial de medidas variables)                                                                        ", "N4+N6       ", "VOLUME (yd3)                                                          ", "No  ", @"^3664(\d{6})", "", 0);
            ia[324] = new ApplicationIdentifiers("3665", "Volumen neto, yardas cúbicas (artículo comercial de medidas variables)                                                                        ", "N4+N6       ", "VOLUME (yd3)                                                          ", "No  ", @"^3665(\d{6})", "", 0);
            ia[325] = new ApplicationIdentifiers("3670", "Volumen Logistic, pulgadas cúbicas                                                                                                            ", "N4+N6       ", "VOLUME (in3), log                                                     ", "No  ", @"^3670(\d{6})", "", 0);
            ia[326] = new ApplicationIdentifiers("3671", "Volumen Logistic, pulgadas cúbicas                                                                                                            ", "N4+N6       ", "VOLUME (in3), log                                                     ", "No  ", @"^3671(\d{6})", "", 0);
            ia[327] = new ApplicationIdentifiers("3672", "Volumen Logistic, pulgadas cúbicas                                                                                                            ", "N4+N6       ", "VOLUME (in3), log                                                     ", "No  ", @"^3672(\d{6})", "", 0);
            ia[328] = new ApplicationIdentifiers("3673", "Volumen Logistic, pulgadas cúbicas                                                                                                            ", "N4+N6       ", "VOLUME (in3), log                                                     ", "No  ", @"^3673(\d{6})", "", 0);
            ia[329] = new ApplicationIdentifiers("3674", "Volumen Logistic, pulgadas cúbicas                                                                                                            ", "N4+N6       ", "VOLUME (in3), log                                                     ", "No  ", @"^3674(\d{6})", "", 0);
            ia[330] = new ApplicationIdentifiers("3675", "Volumen Logistic, pulgadas cúbicas                                                                                                            ", "N4+N6       ", "VOLUME (in3), log                                                     ", "No  ", @"^3675(\d{6})", "", 0);
            ia[331] = new ApplicationIdentifiers("3680", "Volumen logístico, de pies cúbicos                                                                                                            ", "N4+N6       ", "VOLUME (ft3), log                                                     ", "No  ", @"^3680(\d{6})", "", 0);
            ia[332] = new ApplicationIdentifiers("3681", "Volumen logístico, de pies cúbicos                                                                                                            ", "N4+N6       ", "VOLUME (ft3), log                                                     ", "No  ", @"^3681(\d{6})", "", 0);
            ia[333] = new ApplicationIdentifiers("3682", "Volumen logístico, de pies cúbicos                                                                                                            ", "N4+N6       ", "VOLUME (ft3), log                                                     ", "No  ", @"^3682(\d{6})", "", 0);
            ia[334] = new ApplicationIdentifiers("3683", "Volumen logístico, de pies cúbicos                                                                                                            ", "N4+N6       ", "VOLUME (ft3), log                                                     ", "No  ", @"^3683(\d{6})", "", 0);
            ia[335] = new ApplicationIdentifiers("3684", "Volumen logístico, de pies cúbicos                                                                                                            ", "N4+N6       ", "VOLUME (ft3), log                                                     ", "No  ", @"^3684(\d{6})", "", 0);
            ia[336] = new ApplicationIdentifiers("3685", "Volumen logístico, de pies cúbicos                                                                                                            ", "N4+N6       ", "VOLUME (ft3), log                                                     ", "No  ", @"^3685(\d{6})", "", 0);
            ia[337] = new ApplicationIdentifiers("3690", "Volumen logístico, yardas cúbicas                                                                                                             ", "N4+N6       ", "VOLUME (yd3), log                                                     ", "No  ", @"^3690(\d{6})", "", 0);
            ia[338] = new ApplicationIdentifiers("3691", "Volumen logístico, yardas cúbicas                                                                                                             ", "N4+N6       ", "VOLUME (yd3), log                                                     ", "No  ", @"^3691(\d{6})", "", 0);
            ia[339] = new ApplicationIdentifiers("3692", "Volumen logístico, yardas cúbicas                                                                                                             ", "N4+N6       ", "VOLUME (yd3), log                                                     ", "No  ", @"^3692(\d{6})", "", 0);
            ia[340] = new ApplicationIdentifiers("3693", "Volumen logístico, yardas cúbicas                                                                                                             ", "N4+N6       ", "VOLUME (yd3), log                                                     ", "No  ", @"^3693(\d{6})", "", 0);
            ia[341] = new ApplicationIdentifiers("3694", "Volumen logístico, yardas cúbicas                                                                                                             ", "N4+N6       ", "VOLUME (yd3), log                                                     ", "No  ", @"^3694(\d{6})", "", 0);
            ia[342] = new ApplicationIdentifiers("3695", "Volumen logístico, yardas cúbicas                                                                                                             ", "N4+N6       ", "VOLUME (yd3), log                                                     ", "No  ", @"^3695(\d{6})", "", 0);
            ia[343] = new ApplicationIdentifiers("37", "Conteo de artículos comerciales o piezas de artículos comerciales contenidos en una unidad logística                                            ", "N2+N..8     ", "COUNT                                                                 ", "Si  ", @"^37(\d{0,8})", "", 0);
            ia[344] = new ApplicationIdentifiers("3900", "Cantidad aplicable a pagar o valor de cupón/descuento, moneda local                                                                           ", "N4+N..15    ", "AMOUNT                                                                ", "Si  ", @"^3900(\d{0,15})", "", 0);
            ia[345] = new ApplicationIdentifiers("3901", "Cantidad aplicable a pagar o valor de cupón/descuento, moneda local                                                                           ", "N4+N..15    ", "AMOUNT                                                                ", "Si  ", @"^3901(\d{0,15})", "", 0);
            ia[346] = new ApplicationIdentifiers("3902", "Cantidad aplicable a pagar o valor de cupón/descuento, moneda local                                                                           ", "N4+N..15    ", "AMOUNT                                                                ", "Si  ", @"^3902(\d{0,15})", "", 0);
            ia[347] = new ApplicationIdentifiers("3903", "Cantidad aplicable a pagar o valor de cupón/descuento, moneda local                                                                           ", "N4+N..15    ", "AMOUNT                                                                ", "Si  ", @"^3903(\d{0,15})", "", 0);
            ia[348] = new ApplicationIdentifiers("3904", "Cantidad aplicable a pagar o valor de cupón/descuento, moneda local                                                                           ", "N4+N..15    ", "AMOUNT                                                                ", "Si  ", @"^3904(\d{0,15})", "", 0);
            ia[349] = new ApplicationIdentifiers("3905", "Cantidad aplicable a pagar o valor de cupón/descuento, moneda local                                                                           ", "N4+N..15    ", "AMOUNT                                                                ", "Si  ", @"^3905(\d{0,15})", "", 0);
            ia[350] = new ApplicationIdentifiers("3906", "Cantidad aplicable a pagar o valor de cupón/descuento, moneda local                                                                           ", "N4+N..15    ", "AMOUNT                                                                ", "Si  ", @"^3906(\d{0,15})", "", 0);
            ia[351] = new ApplicationIdentifiers("3907", "Cantidad aplicable a pagar o valor de cupón/descuento, moneda local                                                                           ", "N4+N..15    ", "AMOUNT                                                                ", "Si  ", @"^3907(\d{0,15})", "", 0);
            ia[352] = new ApplicationIdentifiers("3908", "Cantidad aplicable a pagar o valor de cupón/descuento, moneda local                                                                           ", "N4+N..15    ", "AMOUNT                                                                ", "Si  ", @"^3908(\d{0,15})", "", 0);
            ia[353] = new ApplicationIdentifiers("3909", "Cantidad aplicable a pagar o valor de cupón/descuento, moneda local                                                                           ", "N4+N..15    ", "AMOUNT                                                                ", "Si  ", @"^3909(\d{0,15})", "", 0);
            ia[354] = new ApplicationIdentifiers("3910", "Cantidad aplicable a pagar con código de moneda ISO                                                                                           ", "N4+N3+N..15 ", "AMOUNT                                                                ", "Si  ", @"^3910(\d{3})(\d{0,15})", "", 0);
            ia[355] = new ApplicationIdentifiers("3911", "Cantidad aplicable a pagar con código de moneda ISO                                                                                           ", "N4+N3+N..15 ", "AMOUNT                                                                ", "Si  ", @"^3911(\d{3})(\d{0,15})", "", 0);
            ia[356] = new ApplicationIdentifiers("3912", "Cantidad aplicable a pagar con código de moneda ISO                                                                                           ", "N4+N3+N..15 ", "AMOUNT                                                                ", "Si  ", @"^3912(\d{3})(\d{0,15})", "", 0);
            ia[357] = new ApplicationIdentifiers("3913", "Cantidad aplicable a pagar con código de moneda ISO                                                                                           ", "N4+N3+N..15 ", "AMOUNT                                                                ", "Si  ", @"^3913(\d{3})(\d{0,15})", "", 0);
            ia[358] = new ApplicationIdentifiers("3914", "Cantidad aplicable a pagar con código de moneda ISO                                                                                           ", "N4+N3+N..15 ", "AMOUNT                                                                ", "Si  ", @"^3914(\d{3})(\d{0,15})", "", 0);
            ia[359] = new ApplicationIdentifiers("3915", "Cantidad aplicable a pagar con código de moneda ISO                                                                                           ", "N4+N3+N..15 ", "AMOUNT                                                                ", "Si  ", @"^3915(\d{3})(\d{0,15})", "", 0);
            ia[360] = new ApplicationIdentifiers("3916", "Cantidad aplicable a pagar con código de moneda ISO                                                                                           ", "N4+N3+N..15 ", "AMOUNT                                                                ", "Si  ", @"^3916(\d{3})(\d{0,15})", "", 0);
            ia[361] = new ApplicationIdentifiers("3917", "Cantidad aplicable a pagar con código de moneda ISO                                                                                           ", "N4+N3+N..15 ", "AMOUNT                                                                ", "Si  ", @"^3917(\d{3})(\d{0,15})", "", 0);
            ia[362] = new ApplicationIdentifiers("3918", "Cantidad aplicable a pagar con código de moneda ISO                                                                                           ", "N4+N3+N..15 ", "AMOUNT                                                                ", "Si  ", @"^3918(\d{3})(\d{0,15})", "", 0);
            ia[363] = new ApplicationIdentifiers("3919", "Cantidad aplicable a pagar con código de moneda ISO                                                                                           ", "N4+N3+N..15 ", "AMOUNT                                                                ", "Si  ", @"^3919(\d{3})(\d{0,15})", "", 0);
            ia[364] = new ApplicationIdentifiers("3920", "Importe aplicable a pagar, zona monetaria única (artículo comercial de medida variable)                                                       ", "N4+N..15    ", "PRICE                                                                 ", "Si  ", @"^3920(\d{0,15})", "", 0);
            ia[365] = new ApplicationIdentifiers("3921", "Importe aplicable a pagar, zona monetaria única (artículo comercial de medida variable)                                                       ", "N4+N..15    ", "PRICE                                                                 ", "Si  ", @"^3921(\d{0,15})", "", 0);
            ia[366] = new ApplicationIdentifiers("3922", "Importe aplicable a pagar, zona monetaria única (artículo comercial de medida variable)                                                       ", "N4+N..15    ", "PRICE                                                                 ", "Si  ", @"^3922(\d{0,15})", "", 0);
            ia[367] = new ApplicationIdentifiers("3923", "Importe aplicable a pagar, zona monetaria única (artículo comercial de medida variable)                                                       ", "N4+N..15    ", "PRICE                                                                 ", "Si  ", @"^3923(\d{0,15})", "", 0);
            ia[368] = new ApplicationIdentifiers("3924", "Importe aplicable a pagar, zona monetaria única (artículo comercial de medida variable)                                                       ", "N4+N..15    ", "PRICE                                                                 ", "Si  ", @"^3924(\d{0,15})", "", 0);
            ia[369] = new ApplicationIdentifiers("3925", "Importe aplicable a pagar, zona monetaria única (artículo comercial de medida variable)                                                       ", "N4+N..15    ", "PRICE                                                                 ", "Si  ", @"^3925(\d{0,15})", "", 0);
            ia[370] = new ApplicationIdentifiers("3926", "Importe aplicable a pagar, zona monetaria única (artículo comercial de medida variable)                                                       ", "N4+N..15    ", "PRICE                                                                 ", "Si  ", @"^3926(\d{0,15})", "", 0);
            ia[371] = new ApplicationIdentifiers("3927", "Importe aplicable a pagar, zona monetaria única (artículo comercial de medida variable)                                                       ", "N4+N..15    ", "PRICE                                                                 ", "Si  ", @"^3927(\d{0,15})", "", 0);
            ia[372] = new ApplicationIdentifiers("3928", "Importe aplicable a pagar, zona monetaria única (artículo comercial de medida variable)                                                       ", "N4+N..15    ", "PRICE                                                                 ", "Si  ", @"^3928(\d{0,15})", "", 0);
            ia[373] = new ApplicationIdentifiers("3929", "Importe aplicable a pagar, zona monetaria única (artículo comercial de medida variable)                                                       ", "N4+N..15    ", "PRICE                                                                 ", "Si  ", @"^3929(\d{0,15})", "", 0);
            ia[374] = new ApplicationIdentifiers("3930", "Importe aplicable a pagar con código de moneda ISO (artículo comercial de medida variable)                                                    ", "N4+N3+N..15 ", "PRICE                                                                 ", "Si  ", @"^3930(\d{3})(\d{0,15})", "", 0);
            ia[375] = new ApplicationIdentifiers("3931", "Importe aplicable a pagar con código de moneda ISO (artículo comercial de medida variable)                                                    ", "N4+N3+N..15 ", "PRICE                                                                 ", "Si  ", @"^3931(\d{3})(\d{0,15})", "", 0);
            ia[376] = new ApplicationIdentifiers("3932", "Importe aplicable a pagar con código de moneda ISO (artículo comercial de medida variable)                                                    ", "N4+N3+N..15 ", "PRICE                                                                 ", "Si  ", @"^3932(\d{3})(\d{0,15})", "", 0);
            ia[377] = new ApplicationIdentifiers("3933", "Importe aplicable a pagar con código de moneda ISO (artículo comercial de medida variable)                                                    ", "N4+N3+N..15 ", "PRICE                                                                 ", "Si  ", @"^3933(\d{3})(\d{0,15})", "", 0);
            ia[378] = new ApplicationIdentifiers("3934", "Importe aplicable a pagar con código de moneda ISO (artículo comercial de medida variable)                                                    ", "N4+N3+N..15 ", "PRICE                                                                 ", "Si  ", @"^3934(\d{3})(\d{0,15})", "", 0);
            ia[379] = new ApplicationIdentifiers("3935", "Importe aplicable a pagar con código de moneda ISO (artículo comercial de medida variable)                                                    ", "N4+N3+N..15 ", "PRICE                                                                 ", "Si  ", @"^3935(\d{3})(\d{0,15})", "", 0);
            ia[380] = new ApplicationIdentifiers("3936", "Importe aplicable a pagar con código de moneda ISO (artículo comercial de medida variable)                                                    ", "N4+N3+N..15 ", "PRICE                                                                 ", "Si  ", @"^3936(\d{3})(\d{0,15})", "", 0);
            ia[381] = new ApplicationIdentifiers("3937", "Importe aplicable a pagar con código de moneda ISO (artículo comercial de medida variable)                                                    ", "N4+N3+N..15 ", "PRICE                                                                 ", "Si  ", @"^3937(\d{3})(\d{0,15})", "", 0);
            ia[382] = new ApplicationIdentifiers("3938", "Importe aplicable a pagar con código de moneda ISO (artículo comercial de medida variable)                                                    ", "N4+N3+N..15 ", "PRICE                                                                 ", "Si  ", @"^3938(\d{3})(\d{0,15})", "", 0);
            ia[383] = new ApplicationIdentifiers("3939", "Importe aplicable a pagar con código de moneda ISO (artículo comercial de medida variable)                                                    ", "N4+N3+N..15 ", "PRICE                                                                 ", "Si  ", @"^3939(\d{3})(\d{0,15})", "", 0);
            ia[384] = new ApplicationIdentifiers("3940", "Porcentaje de descuento de un cupón                                                                                                           ", "N4+N4       ", "PRCNT OFF                                                             ", "Si  ", @"^3940(\d{4})", "", 0);
            ia[385] = new ApplicationIdentifiers("3941", "Porcentaje de descuento de un cupón                                                                                                           ", "N4+N4       ", "PRCNT OFF                                                             ", "Si  ", @"^3941(\d{4})", "", 0);
            ia[386] = new ApplicationIdentifiers("3942", "Porcentaje de descuento de un cupón                                                                                                           ", "N4+N4       ", "PRCNT OFF                                                             ", "Si  ", @"^3942(\d{4})", "", 0);
            ia[387] = new ApplicationIdentifiers("3943", "Porcentaje de descuento de un cupón                                                                                                           ", "N4+N4       ", "PRCNT OFF                                                             ", "Si  ", @"^3943(\d{4})", "", 0);
            ia[388] = new ApplicationIdentifiers("400", "Número de orden de compra del cliente                                                                                                          ", "N3+X..30    ", "ORDER NUMBER                                                          ", "Si  ", @"^400([\x21-\x22\x25-\x2F\x30-\x39\x41-\x5A\x5F\x61-\x7A]{0,30})", "", 0);
            ia[389] = new ApplicationIdentifiers("401", "Número de Identificación Global para Consignación (GINC)                                                                                       ", "N3+X..30    ", "GINC                                                                  ", "Si  ", @"^401([\x21-\x22\x25-\x2F\x30-\x39\x41-\x5A\x5F\x61-\x7A]{0,30})", "", 0);
            ia[390] = new ApplicationIdentifiers("402", "Número de Identificación Global de Envío (GSIN)                                                                                                ", "N3+N17      ", "GSIN                                                                  ", "Si  ", @"^402(\d{17})", "", 0);
            ia[391] = new ApplicationIdentifiers("403", "Código de enrutamiento                                                                                                                         ", "N3+X..30    ", "ROUTE                                                                 ", "Si  ", @"^403([\x21-\x22\x25-\x2F\x30-\x39\x41-\x5A\x5F\x61-\x7A]{0,30})", "", 0);
            ia[392] = new ApplicationIdentifiers("410", "Enviar a - Enviar a Número Global de Localización                                                                                              ", "N3+N13      ", "SHIP TO LOC                                                           ", "No  ", @"^410(\d{13})", "", 0);
            ia[393] = new ApplicationIdentifiers("411", "Cobrar a - Facturar a Número Global de Localización                                                                                            ", "N3+N13      ", "BILL TO                                                               ", "No  ", @"^411(\d{13})", "", 0);
            ia[394] = new ApplicationIdentifiers("412", "Comprado de Número Global de Localización                                                                                                      ", "N3+N13      ", "PURCHASE FROM                                                         ", "No  ", @"^412(\d{13})", "", 0);
            ia[395] = new ApplicationIdentifiers("413", "Enviar para - Entregar - Reenviar a Número Global de Localización                                                                              ", "N3+N13      ", "SHIP FOR LOC                                                          ", "No  ", @"^413(\d{13})", "", 0);
            ia[396] = new ApplicationIdentifiers("414", "Identificación de un lugar físico - Número de Localización Global                                                                              ", "N3+N13      ", "LOC No                                                                ", "No  ", @"^414(\d{13})", "", 0);
            ia[397] = new ApplicationIdentifiers("415", "Número Global de Localización del emisor de la factura                                                                                         ", "N3+N13      ", "PAY TO                                                                ", "No  ", @"^415(\d{13})", "", 0);
            ia[398] = new ApplicationIdentifiers("416", "GLN del lugar de producción o servicio                                                                                                         ", "N3+N13      ", "PROD/SERV LOC                                                         ", "No  ", @"^416(\d{13})", "", 0);
            ia[399] = new ApplicationIdentifiers("417", "GLN de la empresa                                                                                                                              ", "N3+N13      ", "PARTY                                                                 ", "No  ", @"^417(\d{13})", "", 0);
            ia[400] = new ApplicationIdentifiers("420", "Enviar a - Enviar a código postal dentro de una única autoridad postal                                                                         ", "N3+X..20    ", "SHIP TO POST                                                          ", "Si  ", @"^420([\x21-\x22\x25-\x2F\x30-\x39\x41-\x5A\x5F\x61-\x7A]{0,20})", "", 0);
            ia[401] = new ApplicationIdentifiers("421", "Enviar a - Enviar a código postal con código de país ISO                                                                                       ", "N3+N3+X..9  ", "SHIP TO POST                                                          ", "Si  ", @"^421(\d{3})([\x21-\x22\x25-\x2F\x30-\x39\x41-\x5A\x5F\x61-\x7A]{0,9})", "", 0);
            ia[402] = new ApplicationIdentifiers("422", "País de origen de un artículo comercial                                                                                                        ", "N3+N3       ", "ORIGIN                                                                ", "Si  ", @"^422(\d{3})", "", 0);
            ia[403] = new ApplicationIdentifiers("423", "País de procesamiento inicial                                                                                                                  ", "N3+N3+N..12 ", "COUNTRY - INITIAL PROCESS.                                            ", "Si  ", @"^423(\d{3})(\d{0,12})", "", 0);
            ia[404] = new ApplicationIdentifiers("424", "País de procesamiento                                                                                                                          ", "N3+N3       ", "COUNTRY - PROCESS.                                                    ", "Si  ", @"^424(\d{3})", "", 0);
            ia[405] = new ApplicationIdentifiers("425", "País de desmontaje                                                                                                                             ", "N3+N3+N..12 ", "COUNTRY - DISASSEMBLY                                                 ", "Si  ", @"^425(\d{3})(\d{0,12})", "", 0);
            ia[406] = new ApplicationIdentifiers("426", "País cubriendo cadena de proceso completa                                                                                                      ", "N3+N3       ", "COUNTRY - FULL PROCESS                                                ", "Si  ", @"^426(\d{3})", "", 0);
            ia[407] = new ApplicationIdentifiers("427", "Subdivisión de país de origen                                                                                                                  ", "N3+X..3     ", "ORIGIN SUBDIVISION                                                    ", "Si  ", @"^427([\x21-\x22\x25-\x2F\x30-\x39\x41-\x5A\x5F\x61-\x7A]{0,3})", "", 0);
            ia[408] = new ApplicationIdentifiers("7001", "OTAN Número de stock (NSN)                                                                                                                    ", "N4+N13      ", "NSN                                                                   ", "Si  ", @"^7001(\d{13})", "", 0);
            ia[409] = new ApplicationIdentifiers("7002", "ONU / ECE clasificación de canales y cortes de carne                                                                                          ", "N4+X..30    ", "MEAT CUT                                                              ", "Si  ", @"^7002([\x21-\x22\x25-\x2F\x30-\x39\x41-\x5A\x5F\x61-\x7A]{0,30})", "", 0);
            ia[410] = new ApplicationIdentifiers("7003", "Fecha y hora de caducidad                                                                                                                     ", "N4+N10      ", "EXPIRY TIME                                                           ", "Si  ", @"^7003(\d{10})", "", 0);
            ia[411] = new ApplicationIdentifiers("7004", "Potencia activa                                                                                                                               ", "N4+N..4     ", "ACTIVE POTENCY                                                        ", "Si  ", @"^7004(\d{0,4})", "", 0);
            ia[412] = new ApplicationIdentifiers("7005", "Zona de captura                                                                                                                               ", "N4+X..12    ", "CATCH AREA                                                            ", "Si  ", @"^7005([\x21-\x22\x25-\x2F\x30-\x39\x41-\x5A\x5F\x61-\x7A]{0,12})", "", 0);
            ia[413] = new ApplicationIdentifiers("7006", "Primera fecha de congelación                                                                                                                  ", "N4+N6       ", "FIRST FREEZE DATE                                                     ", "Si  ", @"^7006(\d{6})", "", 0);
            ia[414] = new ApplicationIdentifiers("7007", "Fecha de cosecha                                                                                                                              ", "N4+N6..12   ", "HARVEST DATE                                                          ", "Si  ", @"^7007(\d{6,12})", "", 0);
            ia[415] = new ApplicationIdentifiers("7008", "Especies con fines pesqueros                                                                                                                  ", "N4+X..3     ", "AQUATIC SPECIES                                                       ", "Si  ", @"^7008([\x21-\x22\x25-\x2F\x30-\x39\x41-\x5A\x5F\x61-\x7A]{0,3})", "", 0);
            ia[416] = new ApplicationIdentifiers("7009", "Tipo de equipo de Pesca                                                                                                                       ", "N4+X..10    ", "FISHING GEAR TYPE                                                     ", "Si  ", @"^7009([\x21-\x22\x25-\x2F\x30-\x39\x41-\x5A\x5F\x61-\x7A]{0,10})", "", 0);
            ia[417] = new ApplicationIdentifiers("7010", "Método de producción                                                                                                                          ", "N4+X..2     ", "PROD METHOD                                                           ", "Si  ", @"^7010([\x21-\x22\x25-\x2F\x30-\x39\x41-\x5A\x5F\x61-\x7A]{0,2})", "", 0);
            ia[418] = new ApplicationIdentifiers("7020", "ID de lote remodelación                                                                                                                       ", "N4+X..20    ", "REFURB LOT                                                            ", "Si  ", @"^7020([\x21-\x22\x25-\x2F\x30-\x39\x41-\x5A\x5F\x61-\x7A]{0,20})", "", 0);
            ia[419] = new ApplicationIdentifiers("7021", "Estado funcional                                                                                                                              ", "N4+X..20    ", "FUNC STAT                                                             ", "Si  ", @"^7021([\x21-\x22\x25-\x2F\x30-\x39\x41-\x5A\x5F\x61-\x7A]{0,20})", "", 0);
            ia[420] = new ApplicationIdentifiers("7022", "Estado de revisión                                                                                                                            ", "N4+X..20    ", "REV STAT                                                              ", "Si  ", @"^7022([\x21-\x22\x25-\x2F\x30-\x39\x41-\x5A\x5F\x61-\x7A]{0,20})", "", 0);
            ia[421] = new ApplicationIdentifiers("7023", "Identificador Global de un Bien Individual (GIAI) de un ensamblado                                                                            ", "N4+X..30    ", "GIAI - ASSEMBLY                                                       ", "Si  ", @"^7023([\x21-\x22\x25-\x2F\x30-\x39\x41-\x5A\x5F\x61-\x7A]{0,30})", "", 0);
            ia[422] = new ApplicationIdentifiers("7030", "Número de procesador con código de país ISO                                                                                                   ", "N4+N3+X..27 ", "PROCESSOR # 0                                                         ", "Si  ", @"^7030(\d{3})([\x21-\x22\x25-\x2F\x30-\x39\x41-\x5A\x5F\x61-\x7A]{0,27})", "", 0);
            ia[423] = new ApplicationIdentifiers("7031", "Número de procesador con código de país ISO                                                                                                   ", "N4+N3+X..27 ", "PROCESSOR # 1                                                         ", "Si  ", @"^7031(\d{3})([\x21-\x22\x25-\x2F\x30-\x39\x41-\x5A\x5F\x61-\x7A]{0,27})", "", 0);
            ia[424] = new ApplicationIdentifiers("7032", "Número de procesador con código de país ISO                                                                                                   ", "N4+N3+X..27 ", "PROCESSOR # 2                                                         ", "Si  ", @"^7032(\d{3})([\x21-\x22\x25-\x2F\x30-\x39\x41-\x5A\x5F\x61-\x7A]{0,27})", "", 0);
            ia[425] = new ApplicationIdentifiers("7033", "Número de procesador con código de país ISO                                                                                                   ", "N4+N3+X..27 ", "PROCESSOR # 3                                                         ", "Si  ", @"^7033(\d{3})([\x21-\x22\x25-\x2F\x30-\x39\x41-\x5A\x5F\x61-\x7A]{0,27})", "", 0);
            ia[426] = new ApplicationIdentifiers("7034", "Número de procesador con código de país ISO                                                                                                   ", "N4+N3+X..27 ", "PROCESSOR # 4                                                         ", "Si  ", @"^7034(\d{3})([\x21-\x22\x25-\x2F\x30-\x39\x41-\x5A\x5F\x61-\x7A]{0,27})", "", 0);
            ia[427] = new ApplicationIdentifiers("7035", "Número de procesador con código de país ISO                                                                                                   ", "N4+N3+X..27 ", "PROCESSOR # 5                                                         ", "Si  ", @"^7035(\d{3})([\x21-\x22\x25-\x2F\x30-\x39\x41-\x5A\x5F\x61-\x7A]{0,27})", "", 0);
            ia[428] = new ApplicationIdentifiers("7036", "Número de procesador con código de país ISO                                                                                                   ", "N4+N3+X..27 ", "PROCESSOR # 6                                                         ", "Si  ", @"^7036(\d{3})([\x21-\x22\x25-\x2F\x30-\x39\x41-\x5A\x5F\x61-\x7A]{0,27})", "", 0);
            ia[429] = new ApplicationIdentifiers("7037", "Número de procesador con código de país ISO                                                                                                   ", "N4+N3+X..27 ", "PROCESSOR # 7                                                         ", "Si  ", @"^7037(\d{3})([\x21-\x22\x25-\x2F\x30-\x39\x41-\x5A\x5F\x61-\x7A]{0,27})", "", 0);
            ia[430] = new ApplicationIdentifiers("7038", "Número de procesador con código de país ISO                                                                                                   ", "N4+N3+X..27 ", "PROCESSOR # 8                                                         ", "Si  ", @"^7038(\d{3})([\x21-\x22\x25-\x2F\x30-\x39\x41-\x5A\x5F\x61-\x7A]{0,27})", "", 0);
            ia[431] = new ApplicationIdentifiers("7039", "Número de procesador con código de país ISO                                                                                                   ", "N4+N3+X..27 ", "PROCESSOR # 9                                                         ", "Si  ", @"^7039(\d{3})([\x21-\x22\x25-\x2F\x30-\x39\x41-\x5A\x5F\x61-\x7A]{0,27})", "", 0);
            ia[432] = new ApplicationIdentifiers("7040", "GS1 UIC con extensión 1 e índice de Importador                                                                                                ", "N4+N1+X3    ", "UIC+EXT                                                               ", "No  ", @"^7040(\d[\x21-\x22\x25-\x2F\x30-\x39\x41-\x5A\x5F\x61-\x7A]{3})", "", 0);
            ia[433] = new ApplicationIdentifiers("710", "Número nacional de reembolso en Salud (NHRN) - PZN Alemania                                                                                    ", "N3+X..20    ", "NHRN PZN                                                              ", "Si  ", @"^710([\x21-\x22\x25-\x2F\x30-\x39\x41-\x5A\x5F\x61-\x7A]{0,20})", "", 0);
            ia[434] = new ApplicationIdentifiers("711", "Número nacional de reembolso en Salud (NHRN) - CIP Francia                                                                                     ", "N3+X..20    ", "NHRN CIP                                                              ", "Si  ", @"^711([\x21-\x22\x25-\x2F\x30-\x39\x41-\x5A\x5F\x61-\x7A]{0,20})", "", 0);
            ia[435] = new ApplicationIdentifiers("712", "Número nacional de reembolso en Salud (NHRN) - CN España                                                                                       ", "N3+X..20    ", "NHRN CN                                                               ", "Si  ", @"^712([\x21-\x22\x25-\x2F\x30-\x39\x41-\x5A\x5F\x61-\x7A]{0,20})", "", 0);
            ia[436] = new ApplicationIdentifiers("713", "Número nacional de reembolso en Salud (NHRN) - DRN Brasil                                                                                      ", "N3+X..20    ", "NHRN DRN                                                              ", "Si  ", @"^713([\x21-\x22\x25-\x2F\x30-\x39\x41-\x5A\x5F\x61-\x7A]{0,20})", "", 0);
            ia[437] = new ApplicationIdentifiers("714", "Número nacional de reembolso en Salud (NHRN) - AIM Portugal                                                                                    ", "N3+X..20    ", "NHRN AIM                                                              ", "Si  ", @"^714([\x21-\x22\x25-\x2F\x30-\x39\x41-\x5A\x5F\x61-\x7A]{0,20})", "", 0);
            ia[438] = new ApplicationIdentifiers("7230", "Referencia para la certificación                                                                                                              ", "N4+X2+X..28 ", "CERT #1                                                               ", "Si  ", @"^7230([\x21-\x22\x25-\x2F\x30-\x39\x41-\x5A\x5F\x61-\x7A]{2,30})", "", 0);
            ia[439] = new ApplicationIdentifiers("7231", "Referencia para la certificación                                                                                                              ", "N4+X2+X..28 ", "CERT #2                                                               ", "Si  ", @"^7231([\x21-\x22\x25-\x2F\x30-\x39\x41-\x5A\x5F\x61-\x7A]{2,30})", "", 0);
            ia[440] = new ApplicationIdentifiers("7232", "Referencia para la certificación                                                                                                              ", "N4+X2+X..28 ", "CERT #3                                                               ", "Si  ", @"^7232([\x21-\x22\x25-\x2F\x30-\x39\x41-\x5A\x5F\x61-\x7A]{2,30})", "", 0);
            ia[441] = new ApplicationIdentifiers("7233", "Referencia para la certificación                                                                                                              ", "N4+X2+X..28 ", "CERT #4                                                               ", "Si  ", @"^7233([\x21-\x22\x25-\x2F\x30-\x39\x41-\x5A\x5F\x61-\x7A]{2,30})", "", 0);
            ia[442] = new ApplicationIdentifiers("7234", "Referencia para la certificación                                                                                                              ", "N4+X2+X..28 ", "CERT #5                                                               ", "Si  ", @"^7234([\x21-\x22\x25-\x2F\x30-\x39\x41-\x5A\x5F\x61-\x7A]{2,30})", "", 0);
            ia[443] = new ApplicationIdentifiers("7235", "Referencia para la certificación                                                                                                              ", "N4+X2+X..28 ", "CERT #6                                                               ", "Si  ", @"^7235([\x21-\x22\x25-\x2F\x30-\x39\x41-\x5A\x5F\x61-\x7A]{2,30})", "", 0);
            ia[444] = new ApplicationIdentifiers("7236", "Referencia para la certificación                                                                                                              ", "N4+X2+X..28 ", "CERT #7                                                               ", "Si  ", @"^7236([\x21-\x22\x25-\x2F\x30-\x39\x41-\x5A\x5F\x61-\x7A]{2,30})", "", 0);
            ia[445] = new ApplicationIdentifiers("7237", "Referencia para la certificación                                                                                                              ", "N4+X2+X..28 ", "CERT #8                                                               ", "Si  ", @"^7237([\x21-\x22\x25-\x2F\x30-\x39\x41-\x5A\x5F\x61-\x7A]{2,30})", "", 0);
            ia[446] = new ApplicationIdentifiers("7238", "Referencia para la certificación                                                                                                              ", "N4+X2+X..28 ", "CERT #9                                                               ", "Si  ", @"^7238([\x21-\x22\x25-\x2F\x30-\x39\x41-\x5A\x5F\x61-\x7A]{2,30})", "", 0);
            ia[447] = new ApplicationIdentifiers("7239", "Referencia para la certificación                                                                                                              ", "N4+X2+X..28 ", "CERT #10                                                              ", "Si  ", @"^7239([\x21-\x22\x25-\x2F\x30-\x39\x41-\x5A\x5F\x61-\x7A]{2,30})", "", 0);
            ia[448] = new ApplicationIdentifiers("7240", "ID de protocolo                                                                                                                               ", "N4+X..20    ", "PROTOCOL                                                              ", "No  ", @"^7240 ([\x21-\x22\x25-\x2F\x30-\x39\x41-\x5A\x5F\x61-\x7A]{0,20})", "", 0);
            ia[449] = new ApplicationIdentifiers("8001", "Número nacional de reembolso en Salud (NHRN) - NHRN País “A”                                                                                  ", "N4+N14      ", "DIMENSIONS                                                            ", "Si  ", @"^8001(\d{14})", "", 0);
            ia[450] = new ApplicationIdentifiers("8002", "Identificador de telefonía móvil celular                                                                                                      ", "N4+X..20    ", "CMT No                                                                ", "Si  ", @"^8002([\x21-\x22\x25-\x2F\x30-\x39\x41-\x5A\x5F\x61-\x7A]{0,20})", "", 0);
            ia[451] = new ApplicationIdentifiers("8003", "Identificador Global de Bien Retornable (GRAI)                                                                                                ", "N4+N14+X..16", "GRAI                                                                  ", "Si  ", @"^8003(\d{14})([\x21-\x22\x25-\x2F\x30-\x39\x41-\x5A\x5F\x61-\x7A]{0,16})", "", 0);
            ia[452] = new ApplicationIdentifiers("8004", "Identificador Global de Bien Individual (GIAI)                                                                                                ", "N4+X..30    ", "GIAI                                                                  ", "Si  ", @"^8004([\x21-\x22\x25-\x2F\x30-\x39\x41-\x5A\x5F\x61-\x7A]{0,30})", "", 0);
            ia[453] = new ApplicationIdentifiers("8005", "Precio por unidad de medida                                                                                                                   ", "N4+N6       ", "PRICE PER UNIT                                                        ", "Si  ", @"^8005(\d{6})", "", 0);
            ia[454] = new ApplicationIdentifiers("8006", "Identification of an individual trade item piece                                                                                              ", "N4+N14+N2+N2", "ITIP                                                                  ", "Si  ", @"^8006(\d{14})(\d{2})(\d{2})", "", 0);
            ia[455] = new ApplicationIdentifiers("8007", "Número de cuenta bancaria internacional (IBAN)                                                                                                ", "N4+X..34    ", "IBAN                                                                  ", "Si  ", @"^8007([\x21-\x22\x25-\x2F\x30-\x39\x41-\x5A\x5F\x61-\x7A]{0,34})", "", 0);
            ia[456] = new ApplicationIdentifiers("8008", "Fecha y hora de la producción                                                                                                                 ", "N4+N8+N..4  ", "PROD TIME                                                             ", "Si  ", @"^8008(\d{8})(\d{0,4})", "", 0);
            ia[457] = new ApplicationIdentifiers("8009", "Indicador del sensor ópticamente legible                                                                                                      ", "N4+X..50    ", "OPTSEN                                                                ", "Si  ", @"^8009([\x21-\x22\x25-\x2F\x30-\x39\x41-\x5A\x5F\x61-\x7A]{0,50})", "", 0);
            ia[458] = new ApplicationIdentifiers("8010", "Identificador de componente / parte (CPID)                                                                                                    ", "N4+Y..30    ", "CPID                                                                  ", "Si  ", @"^8010([\x23\x2D\x2F\x30-\x39\x41-\x5A]{0,30})", "", 0);
            ia[459] = new ApplicationIdentifiers("8011", "Número de serie de identificador de componente / parte de (CPID DE SERIE)                                                                     ", "N4+N..12    ", "CPID SERIAL                                                           ", "Si  ", @"^8011(\d{0,12})", "", 0);
            ia[460] = new ApplicationIdentifiers("8012", "Versión del software                                                                                                                          ", "N4+X..20    ", "VERSION                                                               ", "Si  ", @"^8012([\x21-\x22\x25-\x2F\x30-\x39\x41-\x5A\x5F\x61-\x7A]{0,20})", "", 0);
            ia[461] = new ApplicationIdentifiers("8013", "Número Global de Modelo (GMN)                                                                                                                 ", "N4+X..30    ", "GMN (for medical devices, the default, global data title is BUDI-DI)  ", "Si  ", @"^8013([\x21-\x22\x25-\x2F\x30-\x39\x41-\x5A\x5F\x61-\x7A]{0,30})", "", 0);
            ia[462] = new ApplicationIdentifiers("8017", "Número de Relación de Servicio Global para identificar la relación entre una organización que ofrece servicios y el proveedor de los servicios", "N4+N18      ", "GSRN - PROVIDER                                                       ", "Si  ", @"^8017(\d{18})", "", 0);
            ia[463] = new ApplicationIdentifiers("8018", "Número de Relación de Servicio Global para identificar la relación entre una organización que ofrece servicios y el receptor de los servicios ", "N4+N18      ", "GSRN - RECIPIENT                                                      ", "Si  ", @"^8018(\d{18})", "", 0);
            ia[464] = new ApplicationIdentifiers("8019", "Número de instancia de relación de servicio (SRIN)                                                                                            ", "N4+N..10    ", "SRIN                                                                  ", "Si  ", @"^8019(\d{0,10})", "", 0);
            ia[465] = new ApplicationIdentifiers("8020", "Número de referencia de comprobante de pago                                                                                                   ", "N4+X..25    ", "REF No                                                                ", "Si  ", @"^8020([\x21-\x22\x25-\x2F\x30-\x39\x41-\x5A\x5F\x61-\x7A]{0,25})", "", 0);
            ia[466] = new ApplicationIdentifiers("8026", "Identificación de las piezas de un artículo comercial (ITIP) contenidas en una unidad logística                                               ", "N4+N14+N2+N2", "ITIP CONTENT                                                          ", "Si  ", @"^8026(\d{14})(\d{2})(\d{2})", "", 0);
            ia[467] = new ApplicationIdentifiers("8110", "Identificación de código de cupón para uso en Norte América                                                                                   ", "N4+X..70    ", "                                                                      ", "Si  ", @"^8110([\x21-\x22\x25-\x2F\x30-\x39\x41-\x5A\x5F\x61-\x7A]{0,70})", "", 0);
            ia[468] = new ApplicationIdentifiers("8111", "Puntos de fidelidad de un cupón                                                                                                               ", "N4+N4       ", "POINTS                                                                ", "Si  ", @"^8111(\d{4})", "", 0);
            ia[469] = new ApplicationIdentifiers("8112", "Identificación de código de cupón sin papel para uso en América del Norte                                                                     ", "N4+X..70    ", "                                                                      ", "Si  ", @"^8112([\x21-\x22\x25-\x2F\x30-\x39\x41-\x5A\x5F\x61-\x7A]{0,70})", "", 0);
            ia[470] = new ApplicationIdentifiers("8200", "URL de embalaje extendido                                                                                                                     ", "N4+X..70    ", "PRODUCT URL                                                           ", "Si  ", @"^8200([\x21-\x22\x25-\x2F\x30-\x39\x41-\x5A\x5F\x61-\x7A]{0,70})", "", 0);
            ia[471] = new ApplicationIdentifiers("90", "Información de mutuo acuerdo entre socios comerciales                                                                                           ", "N2+X..30    ", "INTERNAL                                                              ", "Si  ", @"^90([\x21-\x22\x25-\x2F\x30-\x39\x41-\x5A\x5F\x61-\x7A]{0,30})", "", 0);
            ia[472] = new ApplicationIdentifiers("91", "Información interna de compañía                                                                                                                 ", "N2+X..90    ", "INTERNAL                                                              ", "Si  ", @"^91([\x21-\x22\x25-\x2F\x30-\x39\x41-\x5A\x5F\x61-\x7A]{0,90})", "", 0);
            ia[473] = new ApplicationIdentifiers("92", "Información interna de compañía                                                                                                                 ", "N2+X..90    ", "INTERNAL                                                              ", "Si  ", @"^92([\x21-\x22\x25-\x2F\x30-\x39\x41-\x5A\x5F\x61-\x7A]{0,90})", "", 0);
            ia[474] = new ApplicationIdentifiers("93", "Información interna de compañía                                                                                                                 ", "N2+X..90    ", "INTERNAL                                                              ", "Si  ", @"^93([\x21-\x22\x25-\x2F\x30-\x39\x41-\x5A\x5F\x61-\x7A]{0,90})", "", 0);
            ia[475] = new ApplicationIdentifiers("94", "Información interna de compañía                                                                                                                 ", "N2+X..90    ", "INTERNAL                                                              ", "Si  ", @"^94([\x21-\x22\x25-\x2F\x30-\x39\x41-\x5A\x5F\x61-\x7A]{0,90})", "", 0);
            ia[476] = new ApplicationIdentifiers("95", "Información interna de compañía                                                                                                                 ", "N2+X..90    ", "INTERNAL                                                              ", "Si  ", @"^95([\x21-\x22\x25-\x2F\x30-\x39\x41-\x5A\x5F\x61-\x7A]{0,90})", "", 0);
            ia[477] = new ApplicationIdentifiers("96", "Información interna de compañía                                                                                                                 ", "N2+X..90    ", "INTERNAL                                                              ", "Si  ", @"^96([\x21-\x22\x25-\x2F\x30-\x39\x41-\x5A\x5F\x61-\x7A]{0,90})", "", 0);
            ia[478] = new ApplicationIdentifiers("97", "Información interna de compañía                                                                                                                 ", "N2+X..90    ", "INTERNAL                                                              ", "Si  ", @"^97([\x21-\x22\x25-\x2F\x30-\x39\x41-\x5A\x5F\x61-\x7A]{0,90})", "", 0);
            ia[479] = new ApplicationIdentifiers("98", "Información interna de compañía                                                                                                                 ", "N2+X..90    ", "INTERNAL                                                              ", "Si  ", @"^98([\x21-\x22\x25-\x2F\x30-\x39\x41-\x5A\x5F\x61-\x7A]{0,90})", "", 0);
            ia[480] = new ApplicationIdentifiers("99", "Información interna de compañía                                                                                                                 ", "N2+X..90    ", "INTERNAL                                                              ", "Si  ", @"^99([\x21-\x22\x25-\x2F\x30-\x39\x41-\x5A\x5F\x61-\x7A]{0,90})", "", 0);
        }
        public static string[] Decode(string cadena)
        {
            // Declaración variables
            string[] resultado = new string[512];

            // Buscar IA en cadena
            int iaContador = 0;
            int indice = 0;
        inicio:;
            foreach (ApplicationIdentifiers lista in ia)
            {
                string patron = lista.regExp;
                //string entrada = cadena;
                string entrada = cadena.Substring(indice, cadena.Length - indice);

                if (patron != null)
                {
                    MatchCollection matches = Regex.Matches(entrada, patron);

                    foreach (Match match in matches)
                    {
                        Console.WriteLine("Codigo IA  : {0}\t\t\t{1}", lista.codigo, lista.descripcion);
                        Console.WriteLine("Valor      : {0}", match.Groups[1].Value);
                        Console.WriteLine();

                        ia[iaContador].valorCadena = match.Groups[1].Value;


                        indice += (lista.codigo.Length + match.Groups[1].Length);
                        iaContador = -1;
                        goto inicio;
                    }
                }

                iaContador++;
            }

            resultado[2] = ia[0].codigo;

            return resultado;
        }
    }

    class TestEAN128
    {
        static void Main()
        {
            Ean128 E128 = new Ean128();
            string[] a = new string[512];

            Console.WriteLine("                      0000000000111111111122222222223333333333444444444455555555556");
            Console.WriteLine("                      0123456789012345678901234567890123456789012345678901234567890");
            Console.WriteLine();
            
            Console.Write("Introducir el EAN128: ");

            //string ean = Console.ReadLine();

            //string ean = "020800060799745310LB246150708313772";
            //string ean = "011950110153000017140704101AB-123A111";
            string ean = "0199310095000358159508273003";                  // (01)993100950000358(15)950827(30)03
            //string ean = "8018770123400001350767829001030119990630";      // (8018)770 1234 000013507678 2(90)01 03 01 19990630
            //string ean = "01987123456700193102003725251NL21243857";         // (01)98712345670019(3102)003725(251)NL21243857
            Console.WriteLine(ean);

            Console.WriteLine();

            a = Ean128.Decode(ean);

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }


    }
}

