using System.Collections.Generic;
using Shared.Interfaces;
using Shared.Dto;

namespace DAL
{
    // For now, data is either a json file or hard-coded values called here.
    public class TaspaData : ITaspaData
    {
        public List<NavigationLink> GetNavigationLinks()
        {
            var navigationLinks = new List<NavigationLink>();

            navigationLinks.Add(new NavigationLink() { LinkAction = "/Index", LinkText = "Home" });
            navigationLinks.Add(new NavigationLink() { LinkAction = "/Panels/VerbsPanel", LinkText = "Verbs" });
            navigationLinks.Add(new NavigationLink() { LinkAction = "/Panels/VocabularyPanel", LinkText = "Vocabulary" });

            return navigationLinks;
        }

        public List<VocabularyRadioButton> GetVocabularyRadioButtons()
        {
            var vocabularyRadioButtons = new List<VocabularyRadioButton>();

            vocabularyRadioButtons.Add(new VocabularyRadioButton() { LinkText = "Body", Value = "Body", MethodCall = "VocabularyPanelSetVocabularyList('bodyparts', 'TheBody');" });            
            vocabularyRadioButtons.Add(new VocabularyRadioButton() { LinkText = "Clothing", Value = "Clothing", MethodCall = "VocabularyPanelSetVocabularyList('clothing', 'Clothing');" });
            vocabularyRadioButtons.Add(new VocabularyRadioButton() { LinkText = "Colors", Value = "Colors", MethodCall = "VocabularyPanelSetVocabularyList('colors', 'Colors');" });
            vocabularyRadioButtons.Add(new VocabularyRadioButton() { LinkText = "Family Members", Value = "Family Members", MethodCall = "VocabularyPanelSetVocabularyList('familymembers', 'FamilyMembers');" });
            vocabularyRadioButtons.Add(new VocabularyRadioButton() { LinkText = "Fruits", Value = "Fruits", MethodCall = "VocabularyPanelSetVocabularyList('fruits', 'Fruits');" });
            vocabularyRadioButtons.Add(new VocabularyRadioButton() { LinkText = "House Terms", Value = "HouseTerms", MethodCall = "VocabularyPanelSetVocabularyList('houseterms', 'HouseTerms');" });
            vocabularyRadioButtons.Add(new VocabularyRadioButton() { LinkText = "Meetup Group List", Value = "MeetupGroupList", MethodCall = "VocabularyPanelSetVocabularyList('listfrommeetup', 'MeetupGroupList');" });
            vocabularyRadioButtons.Add(new VocabularyRadioButton() { LinkText = "Phrases", Value = "Phrases", MethodCall = "VocabularyPanelSetVocabularyList('phrases', 'Phrases');" });
            vocabularyRadioButtons.Add(new VocabularyRadioButton() { LinkText = "Prepositions", Value = "Prepositions", MethodCall = "VocabularyPanelSetVocabularyList('prepositions', 'Prepositions');" });
            vocabularyRadioButtons.Add(new VocabularyRadioButton() { LinkText = "Questions", Value = "Questions", MethodCall = "VocabularyPanelSetVocabularyList('questions', 'Questions');" });
            vocabularyRadioButtons.Add(new VocabularyRadioButton() { LinkText = "Shops", Value = "Shops", MethodCall = "VocabularyPanelSetVocabularyList('shops', 'Shops');" });
            vocabularyRadioButtons.Add(new VocabularyRadioButton() { LinkText = "Vegetables", Value = "Vegetables", MethodCall = "VocabularyPanelSetVocabularyList('vegetables', 'Vegetables');" });
            vocabularyRadioButtons.Add(new VocabularyRadioButton() { LinkText = "Time", Value = "Time", MethodCall = "VocabularyPanelSetVocabularyList('timewords', 'Time');" });

            return vocabularyRadioButtons;
        }

        #region Vocabulary Lists

        public List<string> GetVocabularyLists()
        {
            var verbLists = new List<string>();

            verbLists.Add("Select list");
            verbLists.Add("Full");
            verbLists.Add("A");
            //verbLists.Add("B");
            //verbLists.Add("C");
            //verbLists.Add("D");
            //verbLists.Add("E");
            //verbLists.Add("F");
            //verbLists.Add("G");
            //verbLists.Add("H");
            //verbLists.Add("I");
            //verbLists.Add("J");
            //verbLists.Add("K");
            //verbLists.Add("L");
            //verbLists.Add("M");
            //verbLists.Add("N");
            //verbLists.Add("O");
            //verbLists.Add("P");
            //verbLists.Add("Q");
            //verbLists.Add("R");
            //verbLists.Add("S");
            //verbLists.Add("T");
            //verbLists.Add("U");
            //verbLists.Add("V");
            //verbLists.Add("W");
            //verbLists.Add("X");
            //verbLists.Add("Y");
            //verbLists.Add("Z");

            return verbLists;
        }

        public List<string> GetVocabularyList_Phrases()
        {
            var list = new List<string>();

            list.Add("alguein_tiene_prisa");
            list.Add("anthro");
            list.Add("asuntos_de_seguridad");
            list.Add("buena_onda");
            list.Add("cabruyendo");
            list.Add("cabrón");
            list.Add("cedo");
            list.Add("chispa");
            list.Add("echarle_un_ojo_los_gatos");
            list.Add("estoy_bien_tal_como_soy");
            list.Add("fugaz");
            list.Add("la_hielera");
            list.Add("mendingo");
            list.Add("necio");
            list.Add("no_sea_chochino");
            list.Add("que_tan_lejos_corriste");
            list.Add("quiero_pasar_los_años_que_me_quedan_sanos");
            list.Add("racimo_de_plátanos");
            list.Add("rapiño");
            list.Add("talcón");
            list.Add("te_cuesta_moverte");
            list.Add("un_par");
            list.Add("vas_a_poder");

            return list;
        }

        public List<string> GetVocabularyList_GetBodyParts()
        {
            var list = new List<string>();

            list.Add("el_brazo");
            list.Add("la_espalda");
            list.Add("la_columna_vertebral");
            list.Add("el_cerebro");
            list.Add("el_pecho");
            list.Add("las_nalgas");
            list.Add("la_pantorrilla");
            list.Add("el_oído");
            list.Add("el_codo");
            list.Add("el_ojo");
            list.Add("el_dedo");
            list.Add("el_pie");
            list.Add("el_pelo");
            list.Add("la_mano");
            list.Add("la_cabeza");
            list.Add("el_corazón");
            list.Add("la_cadera");
            list.Add("el_intestino");
            list.Add("la_rodilla");
            list.Add("la_pierna");
            list.Add("el_hígado");
            list.Add("la_boca");
            list.Add("el_músculo");
            list.Add("el_cuello");
            list.Add("la_nariz");
            list.Add("el_hombro");
            list.Add("la_piel");
            list.Add("el_vientre");
            list.Add("el_estómago");
            list.Add("el_muslo");
            list.Add("la_garganta");
            list.Add("el_dedo");
            list.Add("la_lengua");
            list.Add("el_diente");

            return list;
        }

        public List<string> GetVocabularyList_GetClothing()
        {
            var list = new List<string>();

            list.Add("el_albornoz");
            list.Add("el_cinturón");
            list.Add("la_blusa");
            list.Add("las_botas");
            list.Add("la_gorra");
            list.Add("el_abrigo");
            list.Add("el_vestido");
            list.Add("los_guantes");
            list.Add("el_sombrero");
            list.Add("la_chaqueta");
            list.Add("los_jeans");
            list.Add("la_minifalda");
            list.Add("la_pijama");
            list.Add("los_pantalones");
            list.Add("el_bolso");
            list.Add("el_impermeable");
            list.Add("la_sandalia");
            list.Add("la_camisa");
            list.Add("el_zapato");
            list.Add("los_pantalones_cortos");
            list.Add("la_falda");
            list.Add("la_zapatilla");
            list.Add("el_calcetín");
            list.Add("la_media");
            list.Add("el_traje");
            list.Add("el_suéter");
            list.Add("la_sudadera");
            list.Add("el_traje_de_entrenamiento");
            list.Add("el_bañador");
            list.Add("el_zapato_de_tenis");
            list.Add("la_corbata");
            list.Add("la_camiseta");
            list.Add("la_ropa_interior");
            list.Add("el_reloj");

            return list;
        }

        public List<string> GetVocabularyList_GetColors()
        {
            var list = new List<string>();

            list.Add("rojo");
            list.Add("rosado");
            list.Add("marron");
            list.Add("naranja");
            list.Add("azul");
            list.Add("verde");
            list.Add("amarillo");

            return list;
        }

        public List<string> GetVocabularyList_GetFamilyMembers()
        {
            var list = new List<string>();

            list.Add("padre");
            list.Add("madre");
            list.Add("hermano");
            list.Add("hermana");
            list.Add("suegro");
            list.Add("suegra");
            list.Add("cuñado");
            list.Add("cuñada");
            list.Add("esposo_or_marido");
            list.Add("esposa_or_mujer");
            list.Add("abuelo");
            list.Add("abuela");
            list.Add("hijo");
            list.Add("hija");
            list.Add("nieto");
            list.Add("nieta");
            list.Add("tío");
            list.Add("tía");
            list.Add("primo");
            list.Add("prima");
            list.Add("sobrino");
            list.Add("sobrina");
            list.Add("padrastro");
            list.Add("madrastra");
            list.Add("hijastro");
            list.Add("hijastra");
            list.Add("hermanastro");
            list.Add("hermanastra");
            list.Add("compañero");
            list.Add("compañera");
            list.Add("padrino");
            list.Add("madrina");
            list.Add("ahijado");
            list.Add("ahijada");
            list.Add("amigo");
            list.Add("amiga");

            return list;
        }

        public List<string> GetVocabularyList_GetFruits()
        {
            var list = new List<string>();

            list.Add("la_manzana");
            list.Add("el_damasco_el_albericoque");
            list.Add("el_aguacate");
            list.Add("el_plátano_la_banana");
            list.Add("la_mora_la_zarzamora");
            list.Add("el_arándano");
            list.Add("el_camu_camu");
            list.Add("el_cantalupo");
            list.Add("la_chirimoya");
            list.Add("la_cereza");
            list.Add("el_coco");
            list.Add("el_arándano");
            list.Add("el_dátil");
            list.Add("el_higo");
            list.Add("el_melón_galia");
            list.Add("la_grosella_espinosa");
            list.Add("la_uva");
            list.Add("el_pomelo_la_toronja");
            list.Add("la_fruta_de_guaraná");
            list.Add("el_arándano");
            list.Add("el_kiwi");
            list.Add("el_kinoto");
            list.Add("el_limón");
            list.Add("la_lima");
            list.Add("la_zarza_la_frambuesa");
            list.Add("la_mandarina");
            list.Add("el_mango");
            list.Add("el_melón");
            list.Add("la_mora");
            list.Add("la_naranjilla_el_lulo");
            list.Add("la_nectarina");
            list.Add("la_naranja");
            list.Add("la_papaya");
            list.Add("el_durazno_el_melocotón");
            list.Add("la_pera");
            list.Add("el_caqui");
            list.Add("la_piña_el_ananá");
            list.Add("el_plátano");
            list.Add("la_platanera");
            list.Add("la_ciruela");
            list.Add("la_granada");
            list.Add("la_tuna_el_higo_chumbo");
            list.Add("la_frambuesa");
            list.Add("la_fresa_la_frutilla");
            list.Add("la_mandarina");
            list.Add("el_tomatillo");
            list.Add("el_tomate");
            list.Add("la_sandía");

            return list;
        }

        public List<string> GetVocabularyList_GetMeetupList()
        {
            var list = new List<string>();

            list.Add("el_proximó_viernes");
            list.Add("el_viernes_pasado");
            list.Add("murciélago");
            list.Add("cuanto_tiempo_has_estado_aqui");
            list.Add("durante_cuanto_tiempo_estuviste_aqui");
            list.Add("subir");
            list.Add("escalar");
            list.Add("cola");
            list.Add("fila");
            list.Add("chingo");
            list.Add("banqueta");
            list.Add("recursos_de_viviento");
            list.Add("el_cuarto_mas_viejo");
            list.Add("banca");
            list.Add("banco");
            list.Add("el_culo");
            list.Add("cariño");
            list.Add("en_México_en_todas_partes");
            list.Add("las_tijeras");
            list.Add("la_campana");
            list.Add("las_fuentes");
            list.Add("pluma");
            list.Add("la_cadena");
            list.Add("la_revista");
            list.Add("el_puente");
            list.Add("la_pantalla");
            list.Add("la_bandera");
            list.Add("los_bancos");
            list.Add("la_coasta");
            list.Add("la_carcel");
            list.Add("el_calle");
            list.Add("la_calle_jeros");
            list.Add("la_carretera");
            list.Add("el_autopista");
            list.Add("la_camina");
            list.Add("el_hogar");
            list.Add("la_avenida");
            list.Add("la_esquina");
            list.Add("las_pistas");
            list.Add("la_ruta");
            list.Add("el_dueño");
            list.Add("campo");
            list.Add("disparar");
            list.Add("nunca_falla");
            list.Add("esposas_de_policia");
            list.Add("compartir");
            list.Add("domitorio");
            list.Add("habitacion");
            list.Add("recamara");
            list.Add("comerse");
            list.Add("un_placer");
            list.Add("aunque");
            list.Add("demasiado");
            list.Add("cuidate");
            list.Add("orgullosa");
            list.Add("vaya");
            list.Add("supuesto");
            list.Add("a_veces");
            list.Add("encojer");
            list.Add("césped");
            list.Add("condado");
            list.Add("palepez");
            list.Add("amargo");
            list.Add("tirar");
            list.Add("empujar");
            list.Add("tubo");
            list.Add("prueba");
            list.Add("aquel");
            list.Add("aquellos");
            list.Add("ningun_anyel_arroyo");
            list.Add("relámpagos");
            list.Add("ademas");
            list.Add("quizas");
            list.Add("perezoso");
            list.Add("alrededor");
            list.Add("jamás");
            list.Add("barco");
            list.Add("mentis");
            list.Add("tengo_sueño");
            list.Add("miseria");
            list.Add("modismo");
            list.Add("puerco");
            list.Add("cerdo");
            list.Add("culta");
            list.Add("exito");
            list.Add("acordarse");
            list.Add("pues");
            list.Add("estadounidense");
            list.Add("equipo");
            list.Add("esencialmente");
            list.Add("manteca");
            list.Add("tema");
            list.Add("la_cumbre");
            list.Add("señales");
            list.Add("flaquillo");
            list.Add("flaco");
            list.Add("flaquito");
            list.Add("flaquillo");
            list.Add("flaco");
            list.Add("flaquito");
            list.Add("al_rato");
            list.Add("estas_esperando");
            list.Add("mostaza");
            list.Add("no_he_pudido_regresar");
            list.Add("el_gobierno");
            list.Add("gobernando");
            list.Add("yo_he_estado");
            list.Add("yo_he_ido");
            list.Add("voz");
            list.Add("tengo_una_galleta");
            list.Add("a_todo_partes");
            list.Add("paradas_continua");
            list.Add("dejando_el_cuidad");
            list.Add("mitad");
            list.Add("asi_corro");
            list.Add("chanka");
            list.Add("contratando");
            list.Add("nivel");
            list.Add("compatir");
            list.Add("como_lo_estoy_haciendo");
            list.Add("me_voy_a_banar");
            list.Add("entreviste");
            list.Add("maestro_suplente");
            list.Add("estoy_un_soldado_en_el_ejercito");
            list.Add("nosotros_jugamos_básquetbol");
            list.Add("güey");
            list.Add("libre");
            list.Add("totops");
            list.Add("lilli_le_gusta_cariño_mucho");
            list.Add("elote");
            list.Add("paquete_de_programma");
            list.Add("voy_a_bañarme");

            return list;
        }

        public List<string> GetVocabularyList_GetPrepositions()
        {
            var list = new List<string>();

            list.Add("a");
            list.Add("antes_de");
            list.Add("acerca_a");
            list.Add("bajo");
            list.Add("cerca_de");
            list.Add("contra");
            list.Add("de");
            list.Add("delante_de");
            list.Add("dentro_de");
            list.Add("desde");
            list.Add("después_de");
            list.Add("detrás_de");
            list.Add("durante");
            list.Add("en");
            list.Add("encima_de");
            list.Add("enfrente_de");
            list.Add("entre");
            list.Add("fuera_de");
            list.Add("hacia");
            list.Add("hasta");
            list.Add("para");
            list.Add("por");
            list.Add("según");
            list.Add("sin");
            list.Add("sobre");
            list.Add("tras");
            list.Add("entonces");
            list.Add("luego");
            list.Add("cada");
            list.Add("orale");
            list.Add("pues");
            list.Add("si");
            list.Add("ya");
            list.Add("nuestro");
            list.Add("hecho");
            list.Add("cualquier");
            list.Add("nunca");
            list.Add("mayor");
            list.Add("acá");
            list.Add("todavía");
            list.Add("lejos");
            list.Add("junto");
            list.Add("adentro");
            list.Add("junto");
            list.Add("flojo");
            list.Add("rico");
            list.Add("tan");
            list.Add("otra_vez");
            list.Add("exigente");
            list.Add("enamorado");
            list.Add("ya_se_armo_(slang)");
            list.Add("cualquiera");
            list.Add("pues");
            list.Add("ya");
            list.Add("deje");
            list.Add("juego");
            list.Add("regalo");
            list.Add("algo_mas");

            return list;
        }
        
        public List<string> GetVocabularyList_GetQuestions()
        {
            var list = new List<string>();

            list.Add("por_que");
            list.Add("porque");
            list.Add("cual_cuales_or_que");
            list.Add("cuanto");
            list.Add("cuando");
            list.Add("quien");
            list.Add("donde");
            list.Add("adonde");
            list.Add("como");

            return list;
        }

        public List<string> GetVocabularyList_GetShops()
        {
            var list = new List<string>();

            list.Add("cafe");
            list.Add("carnicería");
            list.Add("cervecería");
            list.Add("confitería");
            list.Add("dentistería");
            list.Add("droguería");
            list.Add("ebanistería");
            list.Add("ferretería");
            list.Add("floristería");
            list.Add("frutería");
            list.Add("heladería");
            list.Add("herboristería");
            list.Add("herrería");
            list.Add("joyería");
            list.Add("juguetería");
            list.Add("lavandería");
            list.Add("lechería");
            list.Add("lencería");
            list.Add("librería");
            list.Add("mueblería");
            list.Add("panadería");
            list.Add("papelería");
            list.Add("pastelería");
            list.Add("peluquería");
            list.Add("pescadería");
            list.Add("perfumería");
            list.Add("pizzería");
            list.Add("sastrería");
            list.Add("sombrerería");
            list.Add("tapicería");
            list.Add("tintotería");
            list.Add("verdulería");
            list.Add("zapatería");

            return list;
        }

        public List<string> GetVocabularyList_GetVegetables()
        {
            var list = new List<string>();

            list.Add("el_espárrago");
            list.Add("el_aguacate");
            list.Add("los_tallos_de_bambú");
            list.Add("el_frijol");
            list.Add("la_remolacha");
            list.Add("la_col_china");
            list.Add("el_brócoli");
            list.Add("col_de_Bruselas");
            list.Add("la_col");
            list.Add("la_zanahoria");
            list.Add("la_yuca");
            list.Add("la_coriflor");
            list.Add("el_apio");
            list.Add("la_acelga");
            list.Add("la_achicoria");
            list.Add("el_garbanzo");
            list.Add("el_maíz");
            list.Add("el_pepino");
            list.Add("la_berenjena");
            list.Add("la_endivia");
            list.Add("el_ajo");
            list.Add("el_jengibre");
            list.Add("el_pimiento_verde");
            list.Add("el_tupinambo");
            list.Add("la_jícama");
            list.Add("el_puerro");
            list.Add("la_lenteja");
            list.Add("el_ruibarbo");
            list.Add("la_lechuga");
            list.Add("el_champiñón");
            list.Add("el_quingombó");
            list.Add("la_cebolla");
            list.Add("el_perejil");
            list.Add("la_chirivía");
            list.Add("los_guisantes");
            list.Add("la_patata");
            list.Add("la_calabaza");
            list.Add("el_rábano");
            list.Add("el_pimiento_rojo");
            list.Add("el_nabo_sueco");
            list.Add("el_chalote");
            list.Add("la_semilla_de_soja");
            list.Add("las_espinacas");
            list.Add("la_acedera");
            list.Add("la_cucurbitácea");
            list.Add("las_habas_verdes");
            list.Add("la_batata");
            list.Add("la_tapioca");
            list.Add("el_tomatillo");
            list.Add("el_tomate");
            list.Add("el_nabo");
            list.Add("la_castaña_de_agua");
            list.Add("el_berro");
            list.Add("el_boniato");
            list.Add("el_calabacín");

            return list;
        }

        public List<string> GetVocabularyList_HouseTerms()

        {
            var list = new List<string>();

            list.Add("el_ático");
            list.Add("el_sótano");
            list.Add("el_baño");
            list.Add("el_dormitorio");
            list.Add("el_ropero");
            list.Add("el_patio");
            list.Add("el_estudio");
            list.Add("el_comedor");
            list.Add("la_entrada");
            list.Add("la_estancia");
            list.Add("el_garage");
            list.Add("la_cocina");
            list.Add("la_sala_de_estar");
            list.Add("el_cuarto");
            list.Add("el_techo");
            list.Add("el_armario");
            list.Add("la_puerta");
            list.Add("el_enchufe");
            list.Add("el_grifo");
            list.Add("el_suelo");
            list.Add("el_mostrador");
            list.Add("la_lámpara");
            list.Add("la_luz");
            list.Add("el_espejo");
            list.Add("el_tejado");
            list.Add("el_fregadero");
            list.Add("la_escalera");
            list.Add("el_váter");
            list.Add("la_pared");
            list.Add("el_muro");
            list.Add("el_piso");
            list.Add("la_ventana");
            list.Add("la_cama");
            list.Add("la_licuadora");
            list.Add("la_silla");
            list.Add("la_cómoda");
            list.Add("el_sofá");
            list.Add("el_lavavajillas");
            list.Add("la_secadora");
            list.Add("la_plancha");
            list.Add("el_horno");
            list.Add("la_estufa");
            list.Add("la_aspiradora");
            list.Add("la_mesa");
            list.Add("el_tostador");
            list.Add("la_lavadora");

            return list;
        }

        public List<string> GetVocabularyList_GetTimeWords()
        {
            var list = new List<string>();

            list.Add("lunes");
            list.Add("martes");
            list.Add("miercoles");
            list.Add("jueves");
            list.Add("viernes");
            list.Add("sabado");
            list.Add("domingo");
            list.Add("enero");
            list.Add("febrero");
            list.Add("marcha");
            list.Add("abril");
            list.Add("mayo");
            list.Add("junio");
            list.Add("julio");
            list.Add("agosto");
            list.Add("septiembre");
            list.Add("octubre");
            list.Add("noviembre");
            list.Add("diciembre");
            list.Add("por_la_mañana");
            list.Add("de_la_mañana");
            list.Add("por_la_tarde");
            list.Add("de_la_tarde");
            list.Add("por_la_noche");
            list.Add("de_la_noche");
            list.Add("la_mañana");
            list.Add("temprano");
            list.Add("mañana_por_la_mañana");
            list.Add("pasado_mañana");
            list.Add("ayer");
            list.Add("anoche");
            list.Add("la_noche_anterior_anteanoche");
            list.Add("vel_lunes_que_viene");
            list.Add("la_semana_que_viene");
            list.Add("el_año_que_viene");
            list.Add("el_lunes_pasado");
            list.Add("la_semana_pasada");
            list.Add("el_año_pasado");
            list.Add("al_medio_día");
            list.Add("a_la_media_noche");
            list.Add("alrededor_de");
            list.Add("de_días");
            list.Add("durante_el_día");
            list.Add("a_tiempo");
            list.Add("en_punto");
            list.Add("tarde");

            return list;
        }

        #endregion

        #region Verbs

        public List<string> GetVerbLists()
        {
            var verbLists = new List<string>();

            verbLists.Add("Select list");
            verbLists.Add("Full");
            verbLists.Add("A");
            verbLists.Add("B");
            verbLists.Add("C");
            verbLists.Add("D");
            verbLists.Add("E");
            verbLists.Add("F");
            verbLists.Add("G");
            verbLists.Add("H");
            verbLists.Add("I");
            verbLists.Add("J");
            //verbLists.Add("K");
            verbLists.Add("L");
            verbLists.Add("M");
            verbLists.Add("N");
            verbLists.Add("O");
            verbLists.Add("P");
            verbLists.Add("Q");
            verbLists.Add("R");
            verbLists.Add("S");
            verbLists.Add("T");
            verbLists.Add("U");
            verbLists.Add("V");
            //verbLists.Add("W");
            //verbLists.Add("X");
            //verbLists.Add("Y");
            verbLists.Add("Z");

            return verbLists;
        }
        public List<string> GetAVerbList()
        {
            var currentVerbList = new List<string>();

            currentVerbList.Add("abrazar");
            currentVerbList.Add("abrir");
            currentVerbList.Add("acabar");
            currentVerbList.Add("aceptar");
            currentVerbList.Add("acercar");
            currentVerbList.Add("aconsejar");
            currentVerbList.Add("acordar");
            currentVerbList.Add("acostar");
            currentVerbList.Add("acudir");
            currentVerbList.Add("adelgazar");
            currentVerbList.Add("adivinar");
            currentVerbList.Add("admitir");
            currentVerbList.Add("adoptar");
            currentVerbList.Add("afeitar");
            currentVerbList.Add("agradar");
            currentVerbList.Add("agarrar");
            currentVerbList.Add("aguantar");
            currentVerbList.Add("ahogar");
            currentVerbList.Add("alcanzar");
            currentVerbList.Add("alejar");
            currentVerbList.Add("alegrar");
            currentVerbList.Add("aletear");
            currentVerbList.Add("almorzar");
            currentVerbList.Add("alquilar");
            currentVerbList.Add("amanecer");
            currentVerbList.Add("amenazar");
            currentVerbList.Add("amar");
            currentVerbList.Add("andar");
            currentVerbList.Add("anotar");
            currentVerbList.Add("apagar");
            currentVerbList.Add("aparecer");
            currentVerbList.Add("aprender");
            currentVerbList.Add("apretar");
            currentVerbList.Add("aprobar");
            currentVerbList.Add("apapachar");
            currentVerbList.Add("apelar");
            currentVerbList.Add("arreglar");
            currentVerbList.Add("arrancar");
            currentVerbList.Add("arrepentir");
            currentVerbList.Add("arruinar");
            currentVerbList.Add("asistir");
            currentVerbList.Add("aspirar");
            currentVerbList.Add("atender");
            currentVerbList.Add("aterrizar");
            currentVerbList.Add("atracar");
            currentVerbList.Add("averiguar");
            currentVerbList.Add("ayudar");
            currentVerbList.Add("azotar");

            return currentVerbList;
        }
        public List<string> GetBVerbList()
        {
            var currentVerbList = new List<string>();

            currentVerbList.Add("bailar");
            currentVerbList.Add("bajar");
            currentVerbList.Add("beber");
            currentVerbList.Add("borrar");
            currentVerbList.Add("botar");
            currentVerbList.Add("brillar");
            currentVerbList.Add("buscar");

            return currentVerbList;
        }
        public List<string> GetCVerbList()
        {
            var currentVerbList = new List<string>();

            currentVerbList.Add("caber");
            currentVerbList.Add("calentar");
            currentVerbList.Add("cambiar");
            currentVerbList.Add("caminar");
            currentVerbList.Add("cantar");
            currentVerbList.Add("cansar");
            currentVerbList.Add("casar");
            currentVerbList.Add("causar");
            currentVerbList.Add("cavar");
            currentVerbList.Add("cazar");
            currentVerbList.Add("cenar");
            currentVerbList.Add("cerrar");
            currentVerbList.Add("charlar");
            currentVerbList.Add("chocar");
            currentVerbList.Add("chupar");
            currentVerbList.Add("cocinar");
            currentVerbList.Add("coger");
            currentVerbList.Add("colocar");
            currentVerbList.Add("colgar");
            currentVerbList.Add("comenzar");
            currentVerbList.Add("comer");
            currentVerbList.Add("comprar");
            currentVerbList.Add("comprender");
            currentVerbList.Add("conducir");
            currentVerbList.Add("confiar");
            currentVerbList.Add("conocer");
            currentVerbList.Add("construir");
            currentVerbList.Add("contar");
            currentVerbList.Add("contestar");
            currentVerbList.Add("conversar");
            currentVerbList.Add("corregir");
            currentVerbList.Add("correr");
            currentVerbList.Add("cortar");
            currentVerbList.Add("costar");
            currentVerbList.Add("coser");
            currentVerbList.Add("crear");
            currentVerbList.Add("crecer");
            currentVerbList.Add("creer");
            currentVerbList.Add("cruzar");
            currentVerbList.Add("cubrir");
            currentVerbList.Add("cuidar");
            currentVerbList.Add("cumplir");

            return currentVerbList;
        }
        public List<string> GetDVerbList()
        {
            var currentVerbList = new List<string>();

            currentVerbList.Add("dar");
            currentVerbList.Add("deber");
            currentVerbList.Add("decidir");
            currentVerbList.Add("decir");
            currentVerbList.Add("dedicar");
            currentVerbList.Add("dejar");
            currentVerbList.Add("demorar");
            currentVerbList.Add("denunciar");
            currentVerbList.Add("deprimir");
            currentVerbList.Add("derribar");
            currentVerbList.Add("desarrollar");
            currentVerbList.Add("desayunar");
            currentVerbList.Add("desahogar");
            //currentVerbList.Add("deshogar");
            currentVerbList.Add("descansar");
            currentVerbList.Add("describir");
            currentVerbList.Add("descubrir");
            currentVerbList.Add("desear");
            currentVerbList.Add("deshacer");
            currentVerbList.Add("despedir");
            currentVerbList.Add("despertar");
            currentVerbList.Add("detener");
            currentVerbList.Add("detentar");
            currentVerbList.Add("dibujar");
            currentVerbList.Add("discutir");
            currentVerbList.Add("disfrutar");
            currentVerbList.Add("dividir");
            currentVerbList.Add("doler");
            currentVerbList.Add("donar");
            currentVerbList.Add("dormir");
            currentVerbList.Add("dudar");

            return currentVerbList;
        }
        public List<string> GetEVerbList()
        {
            var currentVerbList = new List<string>();

            currentVerbList.Add("echar");
            currentVerbList.Add("elegir");
            currentVerbList.Add("enloquecer");
            currentVerbList.Add("egresar");
            currentVerbList.Add("empezar");
            currentVerbList.Add("empreder");
            currentVerbList.Add("encantar");
            currentVerbList.Add("encender");
            currentVerbList.Add("encontrar");
            currentVerbList.Add("enfermar");
            currentVerbList.Add("enojar");
            currentVerbList.Add("engañar");
            currentVerbList.Add("ensayar");
            currentVerbList.Add("entender");
            currentVerbList.Add("entrar");
            currentVerbList.Add("enviar");
            currentVerbList.Add("equivocar");
            currentVerbList.Add("escoger");
            currentVerbList.Add("esconder");
            currentVerbList.Add("escribir");
            currentVerbList.Add("escuchar");
            currentVerbList.Add("esculcar");
            currentVerbList.Add("esperar");
            currentVerbList.Add("estar");
            currentVerbList.Add("estilar");
            currentVerbList.Add("estilar");
            currentVerbList.Add("estrenar");
            currentVerbList.Add("estudiar");
            currentVerbList.Add("exigir");
            currentVerbList.Add("expedir");
            currentVerbList.Add("explicar");

            return currentVerbList;
        }
        public List<string> GetFVerbList()
        {
            var currentVerbList = new List<string>();

            currentVerbList.Add("fallecer");
            currentVerbList.Add("faltar");
            currentVerbList.Add("fijar");
            currentVerbList.Add("fingir");
            currentVerbList.Add("firmar");
            currentVerbList.Add("fracasar");
            currentVerbList.Add("fregar");
            currentVerbList.Add("fumar");
            currentVerbList.Add("fugar");

            return currentVerbList;
        }
        public List<string> GetGVerbList()
        {
            var currentVerbList = new List<string>();

            currentVerbList.Add("ganar");
            currentVerbList.Add("gastar");
            currentVerbList.Add("generar");
            currentVerbList.Add("girar");
            currentVerbList.Add("gozar");
            currentVerbList.Add("granizar");
            currentVerbList.Add("gritar");
            currentVerbList.Add("guardar");
            currentVerbList.Add("gustar");

            return currentVerbList;
        }
        public List<string> GetHVerbList()
        {
            var currentVerbList = new List<string>();

            currentVerbList.Add("haber");
            currentVerbList.Add("hablar");
            currentVerbList.Add("hacer");
            currentVerbList.Add("herir");
            currentVerbList.Add("hervir");

            return currentVerbList;
        }
        public List<string> GetIVerbList()
        {
            var currentVerbList = new List<string>();

            currentVerbList.Add("iniciar");
            currentVerbList.Add("insinuar");
            currentVerbList.Add("invertir");
            currentVerbList.Add("ir");

            return currentVerbList;
        }
        public List<string> GetJVerbList()
        {
            var currentVerbList = new List<string>();

            currentVerbList.Add("jugar");
            currentVerbList.Add("jurar");

            return currentVerbList;
        }
        public List<string> GetLVerbList()
        {
            var currentVerbList = new List<string>();

            currentVerbList.Add("lanzar");
            currentVerbList.Add("lastimar");
            currentVerbList.Add("lavar");
            currentVerbList.Add("leer");
            currentVerbList.Add("limpiar");
            currentVerbList.Add("llegar");
            currentVerbList.Add("llenar");
            currentVerbList.Add("llevar");
            currentVerbList.Add("lograr");
            currentVerbList.Add("luchar");

            return currentVerbList;
        }
        public List<string> GetMVerbList()
        {
            var currentVerbList = new List<string>();

            currentVerbList.Add("maquillar");
            currentVerbList.Add("mandar");
            currentVerbList.Add("marcar");
            currentVerbList.Add("marchar");
            currentVerbList.Add("medir");
            currentVerbList.Add("mejorar");
            currentVerbList.Add("meter");
            currentVerbList.Add("mirar");
            currentVerbList.Add("molestar");
            currentVerbList.Add("morder");
            currentVerbList.Add("morir");
            currentVerbList.Add("mostrar");
            currentVerbList.Add("mover");
            currentVerbList.Add("mudar");

            return currentVerbList;
        }
        public List<string> GetNVerbList()
        {
            var currentVerbList = new List<string>();

            currentVerbList.Add("nadar");
            currentVerbList.Add("necesitar");
            currentVerbList.Add("negar");

            return currentVerbList;
        }
        public List<string> GetOVerbList()
        {
            var currentVerbList = new List<string>();

            currentVerbList.Add("obligar");
            currentVerbList.Add("obtener");
            currentVerbList.Add("ocultar");
            currentVerbList.Add("ofrecer");
            currentVerbList.Add("oir");
            currentVerbList.Add("oler");
            currentVerbList.Add("olvidar");
            currentVerbList.Add("omitir");
            currentVerbList.Add("organizar");
            currentVerbList.Add("otorgar");

            return currentVerbList;
        }
        public List<string> GetPVerbList()
        {
            var currentVerbList = new List<string>();

            currentVerbList.Add("pagar");
            //currentVerbList.Add("pajeabar");
            currentVerbList.Add("parlar");
            currentVerbList.Add("parar");
            currentVerbList.Add("parecer");
            currentVerbList.Add("parir");
            currentVerbList.Add("partir");
            currentVerbList.Add("pasar");
            currentVerbList.Add("patinar");
            currentVerbList.Add("pedir");
            currentVerbList.Add("pegar");
            currentVerbList.Add("peinar");
            currentVerbList.Add("pensar");
            currentVerbList.Add("pesar");
            currentVerbList.Add("perder");
            currentVerbList.Add("permitir");
            currentVerbList.Add("pescar");
            currentVerbList.Add("platicar");
            currentVerbList.Add("poder");
            currentVerbList.Add("poseer");
            currentVerbList.Add("practicar");
            currentVerbList.Add("preferir");
            currentVerbList.Add("preguntar");
            currentVerbList.Add("preparar");
            currentVerbList.Add("prestar");
            currentVerbList.Add("presumir");
            currentVerbList.Add("pretender");
            currentVerbList.Add("prohibir");
            currentVerbList.Add("prometer");
            currentVerbList.Add("pronunciar");
            currentVerbList.Add("proponer");
            currentVerbList.Add("proteger");

            return currentVerbList;
        }
        public List<string> GetQVerbList()
        {
            var currentVerbList = new List<string>();

            currentVerbList.Add("quedar");
            currentVerbList.Add("querer");
            currentVerbList.Add("quemar");
            currentVerbList.Add("quitar");

            return currentVerbList;
        }
        public List<string> GetRVerbList()
        {
            var currentVerbList = new List<string>();

            currentVerbList.Add("realizar");
            currentVerbList.Add("recibir");
            currentVerbList.Add("recargar");
            currentVerbList.Add("recoger");
            currentVerbList.Add("reconocer");
            currentVerbList.Add("reconcilar");
            currentVerbList.Add("recordar");
            currentVerbList.Add("recorrer");
            currentVerbList.Add("regalar");
            currentVerbList.Add("regresar");
            currentVerbList.Add("rehacer");
            currentVerbList.Add("rendir");
            currentVerbList.Add("renovar");
            currentVerbList.Add("reparar");
            currentVerbList.Add("repartir");
            currentVerbList.Add("repetir");
            currentVerbList.Add("responder");
            currentVerbList.Add("resaltar");
            currentVerbList.Add("retrasar");
            currentVerbList.Add("rezar");
            currentVerbList.Add("rodear");
            currentVerbList.Add("rogar");
            currentVerbList.Add("romper");

            return currentVerbList;
        }
        public List<string> GetSVerbList()
        {
            var currentVerbList = new List<string>();

            currentVerbList.Add("saber");
            currentVerbList.Add("salir");
            currentVerbList.Add("saludar");
            currentVerbList.Add("secar");
            currentVerbList.Add("seguir");
            currentVerbList.Add("sentar");
            currentVerbList.Add("sentir");
            currentVerbList.Add("ser");
            currentVerbList.Add("servir");
            currentVerbList.Add("soler");
            currentVerbList.Add("soportar");
            currentVerbList.Add("subir");
            currentVerbList.Add("sufrir");
            currentVerbList.Add("sugerir");
            currentVerbList.Add("sumar");
            currentVerbList.Add("superar");
            currentVerbList.Add("susurrar");

            return currentVerbList;
        }
        public List<string> GetTVerbList()
        {
            var currentVerbList = new List<string>();

            currentVerbList.Add("tardar");
            currentVerbList.Add("temblar");
            currentVerbList.Add("temer");
            currentVerbList.Add("tener");
            currentVerbList.Add("terminar");
            currentVerbList.Add("tirar");
            currentVerbList.Add("tocar");
            currentVerbList.Add("tomar");
            currentVerbList.Add("toser");
            currentVerbList.Add("trabajar");
            currentVerbList.Add("traducir");
            currentVerbList.Add("traer");
            currentVerbList.Add("tratar");
            currentVerbList.Add("tumbar");

            return currentVerbList;
        }
        public List<string> GetUVerbList()
        {
            var currentVerbList = new List<string>();

            currentVerbList.Add("unir");
            currentVerbList.Add("usar");
            currentVerbList.Add("utilizar");

            return currentVerbList;
        }
        public List<string> GetVVerbList()
        {
            var currentVerbList = new List<string>();

            currentVerbList.Add("vender");
            currentVerbList.Add("venir");
            currentVerbList.Add("ver");
            currentVerbList.Add("vestir");
            currentVerbList.Add("viajar");
            currentVerbList.Add("visitar");
            currentVerbList.Add("vivir");
            currentVerbList.Add("volar");
            currentVerbList.Add("volver");

            return currentVerbList;
        }
        public List<string> GetZVerbList()
        {
            var currentVerbList = new List<string>();

            currentVerbList.Add("zarpar");

            return currentVerbList;
        }

        #endregion
    }
}