using System.Collections.Generic;
using Shared.Interfaces;
using Shared.Dto;

namespace DAL
{
    // For now, data is either a json file or hard-coded values called here.
    public class TaspaData : ITaspaData
    {
        public SearchList searchList = new SearchList();

        public List<NavigationLink> GetNavigationLinks()
        {
            var navigationLinks = new List<NavigationLink>();

            navigationLinks.Add(new NavigationLink() { LinkAction = "/Index", LinkText = "Home" });
            //navigationLinks.Add(new NavigationLink() { LinkAction = "/Panels/Chat", LinkText = "Chat" });
            navigationLinks.Add(new NavigationLink() { LinkAction = "/Panels/VerbsPanel", LinkText = "Verbs" });
            navigationLinks.Add(new NavigationLink() { LinkAction = "/Panels/VocabularyPanel", LinkText = "Vocabulary" });

            return navigationLinks;
        }

        public List<NavigationLink> GetVueJsNavigationLinks()
        {
            var navigationLinks = new List<NavigationLink>();

            navigationLinks.Add(new NavigationLink() { LinkAction = "/components/HelloWorld", LinkText = "HelloWorld" });
            //navigationLinks.Add(new NavigationLink() { LinkAction = "/Panels/Chat", LinkText = "Chat" });
            navigationLinks.Add(new NavigationLink() { LinkAction = "/Panels/VerbsPanel", LinkText = "Verbs" });
            navigationLinks.Add(new NavigationLink() { LinkAction = "/Panels/VocabularyPanel", LinkText = "Vocabulary" });

            return navigationLinks;
        }

        public List<VocabularyRadioButton> GetVocabularyRadioButtons()
        {
            var vocabularyRadioButtons = new List<VocabularyRadioButton>();

            vocabularyRadioButtons.Add(new VocabularyRadioButton() { LinkText = "Body", Value = "bodyparts", MethodCall = "VocabularyPanelSetVocabularyList('bodyparts');" });
            vocabularyRadioButtons.Add(new VocabularyRadioButton() { LinkText = "Clothing", Value = "clothing", MethodCall = "VocabularyPanelSetVocabularyList('clothing');" });
            vocabularyRadioButtons.Add(new VocabularyRadioButton() { LinkText = "Colors", Value = "colors", MethodCall = "VocabularyPanelSetVocabularyList('colors');" });
            vocabularyRadioButtons.Add(new VocabularyRadioButton() { LinkText = "Charades", Value = "charades", MethodCall = "VocabularyPanelSetVocabularyList('charades');" });
            vocabularyRadioButtons.Add(new VocabularyRadioButton() { LinkText = "Family Members", Value = "familymembers", MethodCall = "VocabularyPanelSetVocabularyList('familymembers');" });

            vocabularyRadioButtons.Add(new VocabularyRadioButton() { LinkText = "Fruits", Value = "fruits", MethodCall = "VocabularyPanelSetVocabularyList('fruits');" });
            vocabularyRadioButtons.Add(new VocabularyRadioButton() { LinkText = "Fruits2", Value = "fruits2", MethodCall = "VocabularyPanelSetVocabularyList('fruits2');" });

            vocabularyRadioButtons.Add(new VocabularyRadioButton() { LinkText = "House Terms", Value = "houseterms", MethodCall = "VocabularyPanelSetVocabularyList('houseterms');" });
            vocabularyRadioButtons.Add(new VocabularyRadioButton() { LinkText = "House Terms2", Value = "houseterms2", MethodCall = "VocabularyPanelSetVocabularyList('houseterms2');" });

            vocabularyRadioButtons.Add(new VocabularyRadioButton() { LinkText = "Meetup Group List", Value = "listfrommeetup", MethodCall = "VocabularyPanelSetVocabularyList('listfrommeetup');" });
            vocabularyRadioButtons.Add(new VocabularyRadioButton() { LinkText = "Meetup Group List2", Value = "listfrommeetup2", MethodCall = "VocabularyPanelSetVocabularyList('listfrommeetup2');" });
            vocabularyRadioButtons.Add(new VocabularyRadioButton() { LinkText = "Meetup Group List3", Value = "listfrommeetup3", MethodCall = "VocabularyPanelSetVocabularyList('listfrommeetup3');" });
            vocabularyRadioButtons.Add(new VocabularyRadioButton() { LinkText = "Meetup Group List4", Value = "listfrommeetup4", MethodCall = "VocabularyPanelSetVocabularyList('listfrommeetup4');" });

            vocabularyRadioButtons.Add(new VocabularyRadioButton() { LinkText = "Phrases", Value = "phrases", MethodCall = "VocabularyPanelSetVocabularyList('phrases');" });

            vocabularyRadioButtons.Add(new VocabularyRadioButton() { LinkText = "Prepositions", Value = "prepositions", MethodCall = "VocabularyPanelSetVocabularyList('prepositions');" });
            vocabularyRadioButtons.Add(new VocabularyRadioButton() { LinkText = "Prepositions2", Value = "prepositions2", MethodCall = "VocabularyPanelSetVocabularyList('prepositions2');" });

            vocabularyRadioButtons.Add(new VocabularyRadioButton() { LinkText = "Questions", Value = "questions", MethodCall = "VocabularyPanelSetVocabularyList('questions');" });
            vocabularyRadioButtons.Add(new VocabularyRadioButton() { LinkText = "Shops", Value = "shops", MethodCall = "VocabularyPanelSetVocabularyList('shops');" });

            vocabularyRadioButtons.Add(new VocabularyRadioButton() { LinkText = "Vegetables", Value = "vegetables", MethodCall = "VocabularyPanelSetVocabularyList('vegetables');" });
            vocabularyRadioButtons.Add(new VocabularyRadioButton() { LinkText = "Vegetables2", Value = "vegetables2", MethodCall = "VocabularyPanelSetVocabularyList('vegetables2');" });
          
            vocabularyRadioButtons.Add(new VocabularyRadioButton() { LinkText = "Time", Value = "timewords", MethodCall = "VocabularyPanelSetVocabularyList('timewords');" });

            return vocabularyRadioButtons;
        }

        //NOTE: List is generated by Bll.Utilities.CreateSearchLists(args)
        public List<SearchTerm> GetSearchList()
        {
            return this.searchList.GetSearchList();
        }

        #region Vocabulary Lists

        public List<string> GetVocabularyList_MexicoList1()
        {
            var list = new List<string>();

            list.Add("asco_me_das");
            list.Add("balatas_traseras");
            list.Add("casa_de_colina");
            list.Add("Cuando_puedes");
            list.Add("no_hay_pedo");
            list.Add("Por_si_sirve_de_consuelo");
            list.Add("párrafo");
            list.Add("nalga_a_nalga");
            list.Add("travieso-travesura");
            list.Add("Bizca");
            list.Add("balatas_delanteras");
            list.Add("ombligo");
            list.Add("imperdible");
            list.Add("humedales_construidos");
            list.Add("Cometelo");
            list.Add("corajudo");
            list.Add("subasta");
            list.Add("no_manches");
            list.Add("molino");
            list.Add("Fusil");
            list.Add("senderos_y_arroyo");
            list.Add("Jamón_de_pierna_Sabori");
            list.Add("Suero_en_polvo_natural");
            list.Add("leña");
            list.Add("párrafo");
            list.Add("ancho");
        
            return list;
        }

        public List<string> GetVocabularyList_MexicoList2()
        {
            var list = new List<string>();

            list.Add("palillos");
            list.Add("parejo");
            list.Add("te_rindes");
            list.Add("apegado");
            list.Add("cuesta_creer");
            list.Add("desfile");
            list.Add("madre_de_alquiler");
            list.Add("mismo_significado");
            list.Add("pasta_dental");
            list.Add("tu_estas_a_cargo");
            list.Add("mi_tarjeta_pasó");
            list.Add("cerveza_de_trigo");
            list.Add("se_ponchan_llantas");
            list.Add("vete_el_diablo");
            list.Add("puñado_de_chiles");
            list.Add("fijate");
            list.Add("me_queda_lejos");
            list.Add("cacahuete");
            list.Add("miel_de_maple");
            list.Add("faucet");
            list.Add("jarabe_de_maple");
            list.Add("deprisa");
            list.Add("dio_de_baja_el_número");
            list.Add("Que_retorcidos!");
            list.Add("herramienta");
            list.Add("campesino");
            list.Add("corazonada");
            list.Add("guayabera");
            list.Add("picoso");
            list.Add("chiquitita");
            list.Add("nunca_más");
            list.Add("no_quiero_hablar_conmigo_mismo");

            return list;
        }

        public List<Vocabulary> GetVocabularyLists()
        {
            var vocabularyLists = new List<Vocabulary>();

            vocabularyLists.Add(new Vocabulary() { Text = "Select list", Value = "" });
            //verbLists.Add("Full");
            vocabularyLists.Add(new Vocabulary() { Text = "Body", Value = "bodyparts" });
            vocabularyLists.Add(new Vocabulary() { Text = "Clothing", Value = "clothing" });
            vocabularyLists.Add(new Vocabulary() { Text = "Colors", Value = "colors" });
            vocabularyLists.Add(new Vocabulary() { Text = "Charades", Value = "charades" });
            vocabularyLists.Add(new Vocabulary() { Text = "Family Members", Value = "familymembers" });

            vocabularyLists.Add(new Vocabulary() { Text = "Fruits", Value = "fruits" });
            vocabularyLists.Add(new Vocabulary() { Text = "Fruits2", Value = "fruits2" });

            vocabularyLists.Add(new Vocabulary() { Text = "House Terms", Value = "houseterms" });
            vocabularyLists.Add(new Vocabulary() { Text = "House Terms2", Value = "houseterms2" });

            vocabularyLists.Add(new Vocabulary() { Text = "Meetup Group List", Value = "listfrommeetup" });
            vocabularyLists.Add(new Vocabulary() { Text = "Meetup Group List2", Value = "listfrommeetup2" });
            vocabularyLists.Add(new Vocabulary() { Text = "Meetup Group List3", Value = "listfrommeetup3" });
            vocabularyLists.Add(new Vocabulary() { Text = "Meetup Group List4", Value = "listfrommeetup4" });

            vocabularyLists.Add(new Vocabulary() { Text = "Phrases", Value = "phrases" });

            vocabularyLists.Add(new Vocabulary() { Text = "Prepositions", Value = "prepositions" });
            vocabularyLists.Add(new Vocabulary() { Text = "Prepositions2", Value = "prepositions2" });

            vocabularyLists.Add(new Vocabulary() { Text = "Questions", Value = "questions" });
            vocabularyLists.Add(new Vocabulary() { Text = "Shops", Value = "shops" });

            vocabularyLists.Add(new Vocabulary() { Text = "Vegetables", Value = "vegetables" });
            vocabularyLists.Add(new Vocabulary() { Text = "Vegetables2", Value = "vegetables2" });

            vocabularyLists.Add(new Vocabulary() { Text = "Mexico1", Value = "mexico1" });
            vocabularyLists.Add(new Vocabulary() { Text = "Mexico2", Value = "mexico2" });

            vocabularyLists.Add(new Vocabulary() { Text = "Time", Value = "timewords" });

            return vocabularyLists;
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

        public List<string> GetCharadesList()
        {
            var list = new List<string>();

            list.Add("Saltar");
            list.Add("Correr");
            list.Add("Bailar");
            list.Add("Cantar");
            list.Add("Nadar");
            list.Add("Reír");
            list.Add("Llorar");
            list.Add("Dormir");
            list.Add("Despertarse");
            list.Add("Comer");
            list.Add("Beber");
            list.Add("Escribir");
            list.Add("Leer");
            list.Add("Cocinar");
            list.Add("Conducir");
            list.Add("Volar");
            list.Add("Caminar");
            list.Add("Sonreír");
            list.Add("Pensar");
            list.Add("Hablar");
            list.Add("Escuchar");
            list.Add("Mirar");
            list.Add("Pintar");
            list.Add("Dibujar");
            list.Add("Aplaudir");
            list.Add("Silbar");
            list.Add("Besar");
            list.Add("Abrazar");
            list.Add("Dar_la_mano");
            list.Add("Estirar");
            list.Add("Bostezar");
            list.Add("Escabullirse");
            list.Add("Gritar");
            list.Add("Susurrar");
            list.Add("Toser");
            list.Add("Estornudar");
            list.Add("Respirar");
            list.Add("Roncar");
            list.Add("Saludar");
            list.Add("Inclinarse");
            list.Add("Saltar");
            list.Add("Brincar");
            list.Add("Patear");
            list.Add("Lanzar");
            list.Add("Atrapar");
            list.Add("Golpear");
            list.Add("Dar_un_puñetazo");
            list.Add("Rascar");
            list.Add("Hacer_cosquillas");
            list.Add("Guiñar");
            list.Add("Fruncir_el_ceño");
            list.Add("Parpadear");
            list.Add("Asentir");
            list.Add("Negar_con_la_cabeza");
            list.Add("Señalar");
            list.Add("Esconderse");
            list.Add("Buscar");
            list.Add("Saltar_la_cuerda");
            list.Add("Equilibrar");
            list.Add("Hacer_malabares");
            list.Add("Girar");
            list.Add("Voltear");
            list.Add("Jalar");
            list.Add("Empujar");
            list.Add("Levantar");
            list.Add("Cargar");
            list.Add("Soltar");
            list.Add("Caer");
            list.Add("Tropezar");
            list.Add("Deslizarse");
            list.Add("Escalar");
            list.Add("Cavar");
            list.Add("Construir");
            list.Add("Rasgar");
            list.Add("Doblar");
            list.Add("Planchar");
            list.Add("Coser");
            list.Add("Atar");
            list.Add("Desatar");
            list.Add("Soplar");
            list.Add("Morder");
            list.Add("Masticar");
            list.Add("Lamer");
            list.Add("Probar");
            list.Add("Oler");
            list.Add("Hacer_flexiones");
            list.Add("Sentarse");
            list.Add("Pararse");
            list.Add("Arrodillarse");
            list.Add("Acuéstarse");
            list.Add("Afeitarse");
            list.Add("Peinarse");
            list.Add("Cepillarse_los_dientes");
            list.Add("Lavarse_las_manos");
            list.Add("Ducharse");
            list.Add("Vestirse");
            list.Add("Desvestirse");
            list.Add("Abotonarse");
            list.Add("Amarrarse_los_zapatos");
            list.Add("Subir_el_cierre");
            list.Add("Despedirse");
            list.Add("Saludar");
            list.Add("Chasquear_los_dedos");
            list.Add("Estirar_los_brazos");
            list.Add("Cruzar_los_brazos");
            list.Add("Frotarse_los_ojos");
            list.Add("Doblarse");
            list.Add("Flexionar_músculos");
            list.Add("Dar_palmaditas_en_la_espalda");
            list.Add("Masajear");
            list.Add("Cepillarse_los_dientes");
            list.Add("Aplaudir");
            list.Add("Negar_con_la_cabeza");
            list.Add("Deslizarse");
            list.Add("Saludar");
            list.Add("Hablar");
            list.Add("Lamer");
            list.Add("Roncar");
            list.Add("Estirar_los_brazos");
            list.Add("Pintar");
            list.Add("Cocinar");
            list.Add("Inclinarse");
            list.Add("Despedirse");
            list.Add("Atrapar");
            list.Add("Soltar");
            list.Add("Deslizarse");
            list.Add("Gritar");
            list.Add("Soltar");
            list.Add("Roncar");
            list.Add("Soplar");
            list.Add("Deslizarse");
            list.Add("Atar");
            list.Add("Arrodillarse");
            list.Add("Escalar");
            list.Add("Leer");
            list.Add("Construir");
            list.Add("Soltar");
            list.Add("Despedirse");
            list.Add("Llorar");
            list.Add("Saludar");
            list.Add("Masajear");
            list.Add("Hablar");
            list.Add("Construir");
            list.Add("Mirar");
            list.Add("Bailar");
            list.Add("Respirar");
            list.Add("Escuchar");
            list.Add("Lanzar");
            list.Add("Sentarse");
            list.Add("Brincar");
            list.Add("Mirar");
            list.Add("Hablar");
            list.Add("Negar_con_la_cabeza");
            list.Add("Doblarse");
            list.Add("Dibujar");
            list.Add("Cocinar");
            list.Add("Amarrarse_los_zapatos");
            list.Add("Parpadear");
            list.Add("Saltar_la_cuerda");
            list.Add("Doblar");
            list.Add("Lanzar");
            list.Add("Atrapar");
            list.Add("Aplaudir");
            list.Add("Escalar");
            list.Add("Parpadear");
            list.Add("Brincar");
            list.Add("Lavarse_las_manos");
            list.Add("Lavarse_las_manos");
            list.Add("Afeitarse");
            list.Add("Pensar");
            list.Add("Planchar");
            list.Add("Levantar");
            list.Add("Sentarse");
            list.Add("Susurrar");
            list.Add("Cepillarse_los_dientes");
            list.Add("Susurrar");
            list.Add("Dar_un_puñetazo");
            list.Add("Ducharse");
            list.Add("Hablar");
            list.Add("Pintar");
            list.Add("Negar_con_la_cabeza");
            list.Add("Sentarse");
            list.Add("Estirar_los_brazos");
            list.Add("Doblarse");
            list.Add("Cargar");
            list.Add("Cargar");
            list.Add("Saludar");
            list.Add("Dar_un_puñetazo");
            list.Add("Sentarse");
            list.Add("Saltar");
            list.Add("Mirar");
            list.Add("Abotonarse");
            list.Add("Saludar");
            list.Add("Roncar");
            list.Add("Parpadear");
            list.Add("Pensar");
            list.Add("Lamer");
            list.Add("Mirar");
            list.Add("Asentir");
            list.Add("Mirar");
            list.Add("Estirar_los_brazos");
            list.Add("Llorar");
            list.Add("Roncar");
            list.Add("Dar_un_puñetazo");
            list.Add("Susurrar");
            list.Add("Correr");
            list.Add("Sentarse");
            list.Add("Llorar");
            list.Add("Mirar");
            list.Add("Dar_un_puñetazo");
            list.Add("Dibujar");
            list.Add("Arrodillarse");
            list.Add("Cepillarse_los_dientes");
            list.Add("Roncar");
            list.Add("Flexionar_músculos");
            list.Add("Escribir");
            list.Add("Afeitarse");
            list.Add("Planchar");
            list.Add("Masajear");
            list.Add("Escuchar");
            list.Add("Lanzar");
            list.Add("Sentarse");
            list.Add("Sonreír");
            list.Add("Rascar");
            list.Add("Sentarse");
            list.Add("Saludar");
            list.Add("Pintar");
            list.Add("Mirar");
            list.Add("Bailar");
            list.Add("Gritar");
            list.Add("Golpear");
            list.Add("Parpadear");
            list.Add("Sentarse");
            list.Add("Lamer");
            list.Add("Estirar_los_brazos");
            list.Add("Respirar");
            list.Add("Llorar");
            list.Add("Lamer");
            list.Add("Atar");
            list.Add("Sentarse");
            list.Add("Afeitarse");
            list.Add("Atrapar");
            list.Add("Escribir");
            list.Add("Afeitarse");
            list.Add("Respirar");
            list.Add("Roncar");
            list.Add("Pensar");
            list.Add("Lavarse_las_manos");
            list.Add("Cargar");
            list.Add("Lamer");
            list.Add("Afeitarse");
            list.Add("Parpadear");
            list.Add("Construir");
            list.Add("Soplar");
            list.Add("Afeitarse");
            list.Add("Afeitarse");
            list.Add("Atrapar");
            list.Add("Parpadear");
            list.Add("Afeitarse");
            list.Add("Parpadear");
            list.Add("Cargar");
            list.Add("Mirar");
            list.Add("Gritar");
            list.Add("Empujar");
            list.Add("Cargar");
            list.Add("Abrazar");
            list.Add("Abotonarse");
            list.Add("Atrapar");
            list.Add("Construir");
            list.Add("Rascar");
            list.Add("Estirar_los_brazos");
            list.Add("Lanzar");
            list.Add("Ducharse");
            list.Add("Empujar");
            list.Add("Pensar");
            list.Add("Llorar");
            list.Add("Saltar_la_cuerda");
            list.Add("Sonreír");
            list.Add("Negar_con_la_cabeza");
            list.Add("Abrazar");
            list.Add("Soplar");
            list.Add("Atrapar");
            list.Add("Cargar");
            list.Add("Construir");
            list.Add("Afeitarse");
            list.Add("Estirar_los_brazos");
            list.Add("Llorar");
            list.Add("Doblar");
            list.Add("Saludar");
            list.Add("Atrapar");
            list.Add("Lamer");
            list.Add("Pensar");
            list.Add("Dormir");
            list.Add("Lanzar");
            list.Add("Guiñar");
            list.Add("Brincar");
            list.Add("Caer");
            list.Add("Hablar");
            list.Add("Dar_palmaditas_en_la_espalda");
            list.Add("Asentir");
            list.Add("Golpear");
            list.Add("Inclinarse");
            list.Add("Dar_la_mano");
            list.Add("Dormir");
            list.Add("Despedirse");
            list.Add("Beber");
            list.Add("Negar_con_la_cabeza");
            list.Add("Doblar");
            list.Add("Dormir");
            list.Add("Atar");
            list.Add("Asentir");
            list.Add("Afeitarse");
            list.Add("Leer");
            list.Add("Brincar");
            list.Add("Despedirse");
            list.Add("Aplaudir");
            list.Add("Escribir");
            list.Add("Amarrarse_los_zapatos");
            list.Add("Caer");
            list.Add("Respirar");
            list.Add("Saludar");
            list.Add("Lanzar");
            list.Add("Brincar");
            list.Add("Doblar");
            list.Add("Despedirse");
            list.Add("Lavarse_las_manos");
            list.Add("Chasquear_los_dedos");
            list.Add("Escabullirse");
            list.Add("Caminar");
            list.Add("Planchar");
            list.Add("Susurrar");
            list.Add("Despedirse");
            list.Add("Hablar");
            list.Add("Lanzar");
            list.Add("Besar");
            list.Add("Despertarse");
            list.Add("Pintar");
            list.Add("Soltar");
            list.Add("Arrodillarse");
            list.Add("Golpear");
            list.Add("Cavar");
            list.Add("Beber");
            list.Add("Pintar");
            list.Add("Desatar");
            list.Add("Besar");
            list.Add("Sentarse");
            list.Add("Parpadear");
            list.Add("Caer");
            list.Add("Atrapar");
            list.Add("Leer");
            list.Add("Pensar");
            list.Add("Hablar");
            list.Add("Beber");
            list.Add("Afeitarse");
            list.Add("Sonreír");
            list.Add("Cepillarse_los_dientes");
            list.Add("Sonreír");
            list.Add("Atar");
            list.Add("Afeitarse");
            list.Add("Negar_con_la_cabeza");
            list.Add("Sonreír");
            list.Add("Saltar_la_cuerda");
            list.Add("Sonreír");
            list.Add("Parpadear");
            list.Add("Estirar");
            list.Add("Afeitarse");
            list.Add("Fruncir_el_ceño");
            list.Add("Sentarse");
            list.Add("Cruzar_los_brazos");
            list.Add("Respirar");
            list.Add("Aplaudir");
            list.Add("Cavar");
            list.Add("Brincar");
            list.Add("Brincar");
            list.Add("Caminar");
            list.Add("Dormir");
            list.Add("Deslizarse");
            list.Add("Saludar");
            list.Add("Desatar");
            list.Add("Estirar");
            list.Add("Bailar");
            list.Add("Lavarse_las_manos");
            list.Add("Lanzar");
            list.Add("Afeitarse");
            list.Add("Doblar");
            list.Add("Respirar");
            list.Add("Atrapar");
            list.Add("Nadar");
            list.Add("Flexionar_músculos");
            list.Add("Saludar");
            list.Add("Asentir");
            list.Add("Atrapar");
            list.Add("Vestirse");
            list.Add("Sentarse");
            list.Add("Hablar");
            list.Add("Besar");
            list.Add("Atrapar");
            list.Add("Silbar");
            list.Add("Doblar");
            list.Add("Despertarse");
            list.Add("Abrazar");
            list.Add("Roncar");
            list.Add("Mirar");
            list.Add("Masticar");
            list.Add("Doblar");
            list.Add("Brincar");
            list.Add("Estirar_los_brazos");
            list.Add("Lanzar");
            list.Add("Inclinarse");
            list.Add("Lanzar");
            list.Add("Lanzar");
            list.Add("Soplar");
            list.Add("Cargar");
            list.Add("Cargar");
            list.Add("Saludar");
            list.Add("Golpear");
            list.Add("Sonreír");
            list.Add("Lavarse_las_manos");
            list.Add("Despedirse");
            list.Add("Cavar");
            list.Add("Caminar");
            list.Add("Planchar");
            list.Add("Lamer");
            list.Add("Dormir");
            list.Add("Gritar");
            list.Add("Dormir");
            list.Add("Saltar_la_cuerda");
            list.Add("Sentarse");
            list.Add("Dormir");
            list.Add("Desatar");
            list.Add("Caminar");
            list.Add("Escribir");
            list.Add("Gritar");
            list.Add("Llorar");
            list.Add("Dormir");
            list.Add("Asentir");
            list.Add("Gritar");
            list.Add("Estornudar");
            list.Add("Hablar");
            list.Add("Empujar");
            list.Add("Mirar");
            list.Add("Empujar");
            list.Add("Saltar_la_cuerda");
            list.Add("Llorar");
            list.Add("Atrapar");
            list.Add("Dar_la_mano");
            list.Add("Desatar");
            list.Add("Inclinarse");
            list.Add("Reír");
            list.Add("Caminar");
            list.Add("Beber");
            list.Add("Empujar");
            list.Add("Llorar");
            list.Add("Nadar");
            list.Add("Besar");
            list.Add("Dar_un_puñetazo");
            list.Add("Toser");
            list.Add("Doblar");
            list.Add("Golpear");
            list.Add("Dar_un_puñetazo");
            list.Add("Planchar");
            list.Add("Despertarse");
            list.Add("Empujar");
            list.Add("Empujar");
            list.Add("Pensar");
            list.Add("Roncar");
            list.Add("Construir");
            list.Add("Sentarse");
            list.Add("Morder");
            list.Add("Afeitarse");
            list.Add("Roncar");
            list.Add("Saltar");
            list.Add("Roncar");
            list.Add("Brincar");
            list.Add("Dormir");
            list.Add("Hablar");
            list.Add("Saltar");
            list.Add("Lamer");
            list.Add("Sonreír");
            list.Add("Dormir");
            list.Add("Beber");
            list.Add("Masajear");
            list.Add("Soplar");
            list.Add("Parpadear");
            list.Add("Flexionar_músculos");
            list.Add("Gritar");
            list.Add("Arrodillarse");
            list.Add("Sonreír");
            list.Add("Soltar");
            list.Add("Saltar_la_cuerda");
            list.Add("Amarrarse_los_zapatos");
            list.Add("Arrodillarse");
            list.Add("Mirar");
            list.Add("Atrapar");
            list.Add("Soplar");
            list.Add("Besar");
            list.Add("Jalar");
            list.Add("Inclinarse");
            list.Add("Atrapar");
            list.Add("Dar_la_mano");
            list.Add("Cocinar");
            list.Add("Mirar");
            list.Add("Sonreír");
            list.Add("Mirar");
            list.Add("Estirar_los_brazos");
            list.Add("Inclinarse");
            list.Add("Parpadear");
            list.Add("Morder");
            list.Add("Lamer");
            list.Add("Nadar");
            list.Add("Soplar");
            list.Add("Parpadear");
            list.Add("Lanzar");
            list.Add("Escabullirse");
            list.Add("Saltar");
            list.Add("Hablar");
            list.Add("Caer");
            list.Add("Hablar");
            list.Add("Estornudar");
            list.Add("Leer");
            list.Add("Lanzar");
            list.Add("Dormir");
            list.Add("Gritar");
            list.Add("Sentarse");
            list.Add("Pensar");
            list.Add("Reír");
            list.Add("Beber");
            list.Add("Besar");
            list.Add("Atar");
            list.Add("Sonreír");
            list.Add("Escribir");
            list.Add("Asentir");
            list.Add("Besar");
            list.Add("Hablar");
            list.Add("Pintar");
            list.Add("Amarrarse_los_zapatos");
            list.Add("Hacer_malabares");
            list.Add("Lavarse_las_manos");
            list.Add("Construir");
            list.Add("Parpadear");
            list.Add("Jalar");
            list.Add("Mirar");
            list.Add("Dar_un_puñetazo");
            list.Add("Dar_palmaditas_en_la_espalda");
            list.Add("Caer");
            list.Add("Gritar");
            list.Add("Mirar");
            list.Add("Escribir");
            list.Add("Cavar");
            list.Add("Chasquear_los_dedos");
            list.Add("Dormir");
            list.Add("Masajear");
            list.Add("Lamer");
            list.Add("Peinarse");
            list.Add("Respirar");
            list.Add("Dormir");
            list.Add("Sentarse");
            list.Add("Brincar");
            list.Add("Masticar");
            list.Add("Soplar");
            list.Add("Parpadear");
            list.Add("Roncar");
            list.Add("Gritar");
            list.Add("Gritar");
            list.Add("Escalar");
            list.Add("Construir");
            list.Add("Despedirse");
            list.Add("Caer");
            list.Add("Aplaudir");
            list.Add("Soplar");
            list.Add("Atrapar");
            list.Add("Gritar");
            list.Add("Mirar");
            list.Add("Roncar");
            list.Add("Susurrar");
            list.Add("Saludar");
            list.Add("Negar_con_la_cabeza");
            list.Add("Despedirse");
            list.Add("Lanzar");
            list.Add("Dormir");
            list.Add("Morder");
            list.Add("Brincar");
            list.Add("Peinarse");
            list.Add("Sonreír");
            list.Add("Señalar");
            list.Add("Doblarse");
            list.Add("Escalar");
            list.Add("Caminar");
            list.Add("Vestirse");
            list.Add("Llorar");
            list.Add("Mirar");
            list.Add("Construir");
            list.Add("Escribir");
            list.Add("Lanzar");
            list.Add("Afeitarse");
            list.Add("Negar_con_la_cabeza");
            list.Add("Esconderse");
            list.Add("Dormir");
            list.Add("Sentarse");
            list.Add("Pensar");
            list.Add("Beber");
            list.Add("Empujar");
            list.Add("Bailar");
            list.Add("Saltar_la_cuerda");
            list.Add("Asentir");
            list.Add("Saltar_la_cuerda");
            list.Add("Despedirse");
            list.Add("Bailar");
            list.Add("Soplar");
            list.Add("Lanzar");
            list.Add("Buscar");
            list.Add("Lamer");
            list.Add("Dormir");
            list.Add("Lavarse_las_manos");
            list.Add("Pintar");
            list.Add("Hacer_flexiones");
            list.Add("Negar_con_la_cabeza");
            list.Add("Llorar");
            list.Add("Atrapar");
            list.Add("Doblar");
            list.Add("Sentarse");
            list.Add("Doblar");
            list.Add("Cepillarse_los_dientes");
            list.Add("Llorar");
            list.Add("Construir");
            list.Add("Girar");
            list.Add("Dormir");
            list.Add("Saltar");
            list.Add("Negar_con_la_cabeza");
            list.Add("Girar");
            list.Add("Pensar");
            list.Add("Beber");
            list.Add("Cargar");
            list.Add("Girar");
            list.Add("Sentarse");
            list.Add("Dar_palmaditas_en_la_espalda");
            list.Add("Dormir");
            list.Add("Arrodillarse");
            list.Add("Golpear");
            list.Add("Nadar");
            list.Add("Llorar");
            list.Add("Sentarse");
            list.Add("Negar_con_la_cabeza");
            list.Add("Pensar");
            list.Add("Sentarse");
            list.Add("Despedirse");
            list.Add("Hablar");
            list.Add("Flexionar_músculos");
            list.Add("Cruzar_los_brazos");
            list.Add("Atrapar");
            list.Add("Buscar");
            list.Add("Golpear");
            list.Add("Pensar");
            list.Add("Sonreír");
            list.Add("Soplar");
            list.Add("Buscar");
            list.Add("Atrapar");
            list.Add("Morder");
            list.Add("Mirar");
            list.Add("Parpadear");
            list.Add("Sonreír");
            list.Add("Despedirse");
            list.Add("Mirar");
            list.Add("Cruzar_los_brazos");
            list.Add("Amarrarse_los_zapatos");
            list.Add("Empujar");
            list.Add("Atar");
            list.Add("Caminar");
            list.Add("Cruzar_los_brazos");
            list.Add("Rascar");
            list.Add("Mirar");
            list.Add("Dibujar");
            list.Add("Desatar");
            list.Add("Brincar");
            list.Add("Flexionar_músculos");
            list.Add("Cruzar_los_brazos");
            list.Add("Cargar");
            list.Add("Escribir");
            list.Add("Doblarse");
            list.Add("Lanzar");
            list.Add("Empujar");
            list.Add("Chasquear_los_dedos");
            list.Add("Pintar");
            list.Add("Negar_con_la_cabeza");
            list.Add("Construir");
            list.Add("Dar_un_puñetazo");
            list.Add("Sentarse");
            list.Add("Llorar");
            list.Add("Pensar");
            list.Add("Empujar");
            list.Add("Pintar");
            list.Add("Atrapar");
            list.Add("Pintar");
            list.Add("Cargar");
            list.Add("Girar");
            list.Add("Brincar");
            list.Add("Vestirse");
            list.Add("Peinarse");
            list.Add("Sentarse");
            list.Add("Saludar");
            list.Add("Lavarse_las_manos");
            list.Add("Sentarse");
            list.Add("Escribir");
            list.Add("Despedirse");
            list.Add("Morder");
            list.Add("Estirar");
            list.Add("Lamer");
            list.Add("Planchar");
            list.Add("Soplar");
            list.Add("Lanzar");
            list.Add("Saludar");
            list.Add("Saltar");
            list.Add("Lanzar");
            list.Add("Saludar");
            list.Add("Cargar");
            list.Add("Parpadear");
            list.Add("Llorar");
            list.Add("Caminar");
            list.Add("Hacer_cosquillas");
            list.Add("Despedirse");
            list.Add("Saludar");
            list.Add("Cocinar");
            list.Add("Cocinar");
            list.Add("Saltar");
            list.Add("Llorar");
            list.Add("Escuchar");
            list.Add("Reír");
            list.Add("Caminar");
            list.Add("Parpadear");
            list.Add("Cepillarse_los_dientes");
            list.Add("Empujar");
            list.Add("Construir");
            list.Add("Dar_un_puñetazo");
            list.Add("Golpear");
            list.Add("Cavar");
            list.Add("Pensar");
            list.Add("Negar_con_la_cabeza");
            list.Add("Afeitarse");
            list.Add("Doblarse");
            list.Add("Saludar");
            list.Add("Soltar");
            list.Add("Pensar");
            list.Add("Caminar");
            list.Add("Aplaudir");
            list.Add("Sentarse");
            list.Add("Lavarse_las_manos");
            list.Add("Doblar");
            list.Add("Buscar");
            list.Add("Lamer");
            list.Add("Parpadear");
            list.Add("Estirar_los_brazos");
            list.Add("Dormir");
            list.Add("Besar");
            list.Add("Mirar");
            list.Add("Frotarse_los_ojos");
            list.Add("Despedirse");
            list.Add("Dormir");
            list.Add("Inclinarse");
            list.Add("Beber");
            list.Add("Saltar");
            list.Add("Afeitarse");
            list.Add("Atrapar");
            list.Add("Afeitarse");
            list.Add("Reír");
            list.Add("Reír");
            list.Add("Afeitarse");
            list.Add("Soplar");
            list.Add("Deslizarse");
            list.Add("Hablar");
            list.Add("Afeitarse");
            list.Add("Beber");
            list.Add("Soltar");
            list.Add("Saludar");
            list.Add("Beber");
            list.Add("Lavarse_las_manos");
            list.Add("Saltar");
            list.Add("Afeitarse");
            list.Add("Jalar");
            list.Add("Soplar");
            list.Add("Estirar");
            list.Add("Coser");
            list.Add("Abrazar");
            list.Add("Parpadear");
            list.Add("Golpear");
            list.Add("Masticar");
            list.Add("Hablar");
            list.Add("Respirar");
            list.Add("Cargar");
            list.Add("Brincar");
            list.Add("Llorar");
            list.Add("Atrapar");
            list.Add("Escuchar");
            list.Add("Cocinar");
            list.Add("Empujar");
            list.Add("Llorar");
            list.Add("Despedirse");
            list.Add("Asentir");
            list.Add("Peinarse");
            list.Add("Sentarse");
            list.Add("Atrapar");
            list.Add("Cocinar");
            list.Add("Gritar");
            list.Add("Escribir");
            list.Add("Brincar");
            list.Add("Reír");
            list.Add("Pintar");
            list.Add("Dormir");
            list.Add("Construir");
            list.Add("Lavarse_las_manos");
            list.Add("Golpear");
            list.Add("Señalar");
            list.Add("Leer");
            list.Add("Mirar");
            list.Add("Girar");
            list.Add("Golpear");
            list.Add("Pintar");
            list.Add("Arrodillarse");
            list.Add("Caer");
            list.Add("Estirar_los_brazos");
            list.Add("Cantar");
            list.Add("Desatar");
            list.Add("Empujar");
            list.Add("Golpear");
            list.Add("Gritar");
            list.Add("Respirar");
            list.Add("Voltear");
            list.Add("Gritar");
            list.Add("Deslizarse");
            list.Add("Caer");
            list.Add("Hablar");
            list.Add("Lavarse_las_manos");
            list.Add("Hablar");
            list.Add("Pintar");
            list.Add("Deslizarse");
            list.Add("Construir");
            list.Add("Atrapar");
            list.Add("Deslizarse");
            list.Add("Jalar");
            list.Add("Sentarse");
            list.Add("Dar_un_puñetazo");
            list.Add("Respirar");
            list.Add("Empujar");
            list.Add("Beber");
            list.Add("Fruncir_el_ceño");
            list.Add("Parpadear");
            list.Add("Despertarse");
            list.Add("Empujar");
            list.Add("Desatar");
            list.Add("Fruncir_el_ceño");
            list.Add("Cavar");
            list.Add("Cepillarse_los_dientes");
            list.Add("Bailar");
            list.Add("Escribir");
            list.Add("Pensar");
            list.Add("Asentir");
            list.Add("Asentir");
            list.Add("Voltear");
            list.Add("Inclinarse");
            list.Add("Voltear");
            list.Add("Saludar");
            list.Add("Parpadear");
            list.Add("Lamer");
            list.Add("Sonreír");
            list.Add("Lamer");
            list.Add("Mirar");
            list.Add("Lavarse_las_manos");
            list.Add("Negar_con_la_cabeza");
            list.Add("Cargar");
            list.Add("Roncar");
            list.Add("Bailar");
            list.Add("Gritar");
            list.Add("Mirar");
            list.Add("Llorar");
            list.Add("Asentir");
            list.Add("Cargar");
            list.Add("Roncar");
            list.Add("Atrapar");
            list.Add("Sentarse");
            list.Add("Brincar");
            list.Add("Planchar");
            list.Add("Cepillarse_los_dientes");
            list.Add("Lanzar");
            list.Add("Llorar");
            list.Add("Escribir");
            list.Add("Correr");
            list.Add("Buscar");
            list.Add("Conducir");
            list.Add("Vestirse");
            list.Add("Cargar");
            list.Add("Asentir");
            list.Add("Gritar");
            list.Add("Soplar");
            list.Add("Asentir");
            list.Add("Parpadear");
            list.Add("Llorar");
            list.Add("Afeitarse");
            list.Add("Saludar");
            list.Add("Pensar");
            list.Add("Abrazar");
            list.Add("Beber");
            list.Add("Cocinar");
            list.Add("Abrazar");
            list.Add("Sonreír");
            list.Add("Masajear");
            list.Add("Saludar");
            list.Add("Dar_un_puñetazo");
            list.Add("Lavarse_las_manos");
            list.Add("Pintar");
            list.Add("Asentir");
            list.Add("Pensar");
            list.Add("Negar_con_la_cabeza");
            list.Add("Lanzar");
            list.Add("Hablar");
            list.Add("Saltar");
            list.Add("Despedirse");
            list.Add("Construir");
            list.Add("Sentarse");
            list.Add("Sentarse");
            list.Add("Besar");
            list.Add("Guiñar");
            list.Add("Afeitarse");
            list.Add("Pensar");
            list.Add("Dormir");
            list.Add("Cargar");
            list.Add("Saltar");
            list.Add("Parpadear");
            list.Add("Chasquear_los_dedos");
            list.Add("Roncar");
            list.Add("Respirar");
            list.Add("Sonreír");
            list.Add("Atar");
            list.Add("Cocinar");
            list.Add("Escuchar");
            list.Add("Parpadear");
            list.Add("Brincar");
            list.Add("Escribir");
            list.Add("Vestirse");
            list.Add("Doblar");
            list.Add("Cargar");
            list.Add("Vestirse");
            list.Add("Inclinarse");
            list.Add("Escuchar");
            list.Add("Lavarse_las_manos");
            list.Add("Dar_la_mano");
            list.Add("Toser");
            list.Add("Planchar");
            list.Add("Atrapar");
            list.Add("Reír");
            list.Add("Asentir");
            list.Add("Flexionar_músculos");
            list.Add("Lamer");
            list.Add("Asentir");
            list.Add("Saltar_la_cuerda");
            list.Add("Abrazar");
            list.Add("Mirar");
            list.Add("Hablar");
            list.Add("Llorar");
            list.Add("Estirar");
            list.Add("Asentir");
            list.Add("Hacer_cosquillas");
            list.Add("Estirar_los_brazos");
            list.Add("Mirar");
            list.Add("Abrazar");
            list.Add("Escalar");
            list.Add("Cepillarse_los_dientes");
            list.Add("Estirar_los_brazos");
            list.Add("Leer");
            list.Add("Pensar");
            list.Add("Arrodillarse");
            list.Add("Soltar");
            list.Add("Atrapar");
            list.Add("Sentarse");
            list.Add("Cargar");
            list.Add("Dar_palmaditas_en_la_espalda");
            list.Add("Jalar");
            list.Add("Llorar");
            list.Add("Brincar");
            list.Add("Hablar");
            list.Add("Beber");
            list.Add("Peinarse");
            list.Add("Afeitarse");
            list.Add("Dormir");
            list.Add("Sentarse");
            list.Add("Beber");
            list.Add("Fruncir_el_ceño");
            list.Add("Volar");
            list.Add("Volar");
            list.Add("Sentarse");
            list.Add("Amarrarse_los_zapatos");
            list.Add("Brincar");
            list.Add("Doblar");
            list.Add("Morder");
            list.Add("Mirar");
            list.Add("Silbar");
            list.Add("Atrapar");
            list.Add("Roncar");
            list.Add("Chasquear_los_dedos");
            list.Add("Escabullirse");
            list.Add("Roncar");
            list.Add("Acuéstarse");

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
            
            return list;
        }
        
        public List<string> GetVocabularyList_GetFruits2()
        {
            var list = new List<string>();

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
            list.Add("elote");
            list.Add("paquete_de_programma");
            list.Add("voy_a_bañarme");

            return list;
        }

        public List<string> GetVocabularyList_GetMeetupList2()
        {
            var list = new List<string>();

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
            list.Add("libre");
            list.Add("totops");
            list.Add("lilli_le_gusta_cariño_mucho");

            return list;
        }

        public List<string> GetVocabularyList_GetMeetupList3()
        {
            var list = new List<string>();
            
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
            list.Add("estoy_un_soldado_en_el_ejercito");
            list.Add("nosotros_jugamos_básquetbol");
            list.Add("güey");

            return list;
        }

        public List<string> GetVocabularyList_GetMeetupList4()
        {
            var list = new List<string>();
            
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
          
            return list;
        }

        public List<string> GetVocabularyList_GetPrepositions2()
        {
            var list = new List<string>();

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
          
            return list;
        }

        public List<string> GetVocabularyList_GetVegetables2()
        {
            var list = new List<string>();

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
          
            return list;
        }

        public List<string> GetVocabularyList_HouseTerms2()

        {
            var list = new List<string>();

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
            currentVerbList.Add("abarcan");
            currentVerbList.Add("abarcar");
            currentVerbList.Add("abrazar");
            currentVerbList.Add("abrir");
            currentVerbList.Add("acabar");
            currentVerbList.Add("acatar");
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
            currentVerbList.Add("agarrar");
            currentVerbList.Add("agendar");
            currentVerbList.Add("agradar");
            currentVerbList.Add("agregar");
            currentVerbList.Add("aguantar");
            currentVerbList.Add("ahogar");
            currentVerbList.Add("ahorrar");
            currentVerbList.Add("alabar");
            currentVerbList.Add("alcanzar");
            currentVerbList.Add("alegrar");
            currentVerbList.Add("alejar");
            currentVerbList.Add("aletear");
            currentVerbList.Add("alimentar");
            currentVerbList.Add("almorzar");
            currentVerbList.Add("alquilar");
            currentVerbList.Add("amamantar");
            currentVerbList.Add("amanecer");
            currentVerbList.Add("amar");
            currentVerbList.Add("amarrar");
            currentVerbList.Add("amenazar");
            currentVerbList.Add("andar");
            currentVerbList.Add("animar");
            currentVerbList.Add("anotar");
            currentVerbList.Add("antojar");
            currentVerbList.Add("apagar");
            currentVerbList.Add("apapachar");
            currentVerbList.Add("aparecer");
            currentVerbList.Add("apelar");
            currentVerbList.Add("aplastar");
            currentVerbList.Add("apoderar");
            currentVerbList.Add("apostar");
            currentVerbList.Add("applicar");
            currentVerbList.Add("aprender");
            currentVerbList.Add("apretar");
            currentVerbList.Add("aprobar");
            currentVerbList.Add("aprovechar");
            currentVerbList.Add("arrancar");
            currentVerbList.Add("arreglar");
            currentVerbList.Add("arrepentir");
            currentVerbList.Add("arruinar");
            currentVerbList.Add("asistir");
            currentVerbList.Add("asomar");
            currentVerbList.Add("asombrar");
            currentVerbList.Add("aspirar");
            currentVerbList.Add("atender");
            currentVerbList.Add("aterrizar");
            currentVerbList.Add("atorar");
            currentVerbList.Add("atracar");
            currentVerbList.Add("atravesar");
            currentVerbList.Add("atrever");
            currentVerbList.Add("atropellar");
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
            currentVerbList.Add("barrar");
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
            currentVerbList.Add("cansar");
            currentVerbList.Add("cantar");
            currentVerbList.Add("capilla");
            currentVerbList.Add("casar");
            currentVerbList.Add("causar");
            currentVerbList.Add("cavar");
            currentVerbList.Add("cazar");
            currentVerbList.Add("cenar");
            currentVerbList.Add("cerrar");
            currentVerbList.Add("charlar");
            currentVerbList.Add("chocar");
            currentVerbList.Add("chupar");
            currentVerbList.Add("cobrar");
            currentVerbList.Add("cocinar");
            currentVerbList.Add("coger");
            currentVerbList.Add("cojear");
            currentVerbList.Add("colgar");
            currentVerbList.Add("colocar");
            currentVerbList.Add("comentar");
            currentVerbList.Add("comenzar");
            currentVerbList.Add("comer");
            currentVerbList.Add("comprar");
            currentVerbList.Add("comprender");
            currentVerbList.Add("concordar");
            currentVerbList.Add("conducir");
            currentVerbList.Add("confiar");
            currentVerbList.Add("conocer");
            currentVerbList.Add("conseguir");
            currentVerbList.Add("construir");
            currentVerbList.Add("contar");
            currentVerbList.Add("contestar");
            currentVerbList.Add("conversar");
            currentVerbList.Add("corregir");
            currentVerbList.Add("correr");
            currentVerbList.Add("cortar");
            currentVerbList.Add("coser");
            currentVerbList.Add("costar");
            currentVerbList.Add("cotejar");
            currentVerbList.Add("crear");
            currentVerbList.Add("crecer");
            currentVerbList.Add("creer");
            currentVerbList.Add("criar");
            currentVerbList.Add("cruzar");
            currentVerbList.Add("cubrir");
            currentVerbList.Add("cuidar");
            currentVerbList.Add("cumplir");
            currentVerbList.Add("currar");
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
            currentVerbList.Add("deparar");
            currentVerbList.Add("deprimir");
            currentVerbList.Add("derribar");
            currentVerbList.Add("desafiante");
            currentVerbList.Add("desahogar");
            currentVerbList.Add("desarrollar");
            currentVerbList.Add("desayunar");
            currentVerbList.Add("descansar");
            currentVerbList.Add("descartar");
            currentVerbList.Add("describir");
            currentVerbList.Add("descubrir");
            currentVerbList.Add("desear");
            currentVerbList.Add("deshacer");
            currentVerbList.Add("desmayar");
            currentVerbList.Add("despedir");
            currentVerbList.Add("despertar");
            currentVerbList.Add("destacar");
            currentVerbList.Add("detener");
            currentVerbList.Add("detentar");
            currentVerbList.Add("dibujar");
            currentVerbList.Add("digerir");
            currentVerbList.Add("dimesionar");
            currentVerbList.Add("dirigir");
            currentVerbList.Add("discutir");
            currentVerbList.Add("disfrutar");
            currentVerbList.Add("distinguir");
            currentVerbList.Add("dividir");
            currentVerbList.Add("doblar");
            currentVerbList.Add("doler");
            currentVerbList.Add("donar");
            currentVerbList.Add("dormir");
            currentVerbList.Add("dudar");
            currentVerbList.Add("durar");
            return currentVerbList;
        }

        public List<string> GetEVerbList()
        {
            var currentVerbList = new List<string>();
            currentVerbList.Add("echar");
            currentVerbList.Add("edificar");
            currentVerbList.Add("egresar");
            currentVerbList.Add("egresos");
            currentVerbList.Add("elegir");
            currentVerbList.Add("emboscar");
            currentVerbList.Add("empezar");
            currentVerbList.Add("empeñar");
            currentVerbList.Add("empreder");
            currentVerbList.Add("encantar");
            currentVerbList.Add("encender");
            currentVerbList.Add("encomendar");
            currentVerbList.Add("encontrar");
            currentVerbList.Add("enfadar");
            currentVerbList.Add("enfermar");
            currentVerbList.Add("engañar");
            currentVerbList.Add("enloquecer");
            currentVerbList.Add("enojar");
            currentVerbList.Add("ensayar");
            currentVerbList.Add("entender");
            currentVerbList.Add("entrar");
            currentVerbList.Add("envasar");
            currentVerbList.Add("envejecer");
            currentVerbList.Add("enviar");
            currentVerbList.Add("equivocar");
            currentVerbList.Add("escatimar");
            currentVerbList.Add("escoger");
            currentVerbList.Add("esconder");
            currentVerbList.Add("escribir");
            currentVerbList.Add("escuchar");
            currentVerbList.Add("esculcar");
            currentVerbList.Add("esperar");
            currentVerbList.Add("estafa");
            currentVerbList.Add("estallar");
            currentVerbList.Add("estar");
            currentVerbList.Add("estilar");
            currentVerbList.Add("estrenar");
            currentVerbList.Add("estropear");
            currentVerbList.Add("estudiar");
            currentVerbList.Add("evitar");
            currentVerbList.Add("exigir");
            currentVerbList.Add("expedir");
            currentVerbList.Add("explicar");
            currentVerbList.Add("exponer");
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
            currentVerbList.Add("fugar");
            currentVerbList.Add("fumar");
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
            currentVerbList.Add("hallar");
            currentVerbList.Add("heredar");
            currentVerbList.Add("herir");
            currentVerbList.Add("hervir");
            currentVerbList.Add("huir");
            currentVerbList.Add("hundir");
            return currentVerbList;
        }

        public List<string> GetIVerbList()
        {
            var currentVerbList = new List<string>();
            currentVerbList.Add("ingresos");
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
            currentVerbList.Add("legar");
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
            currentVerbList.Add("madrugar");
            currentVerbList.Add("mandar");
            currentVerbList.Add("maquillar");
            currentVerbList.Add("marcar");
            currentVerbList.Add("marchar");
            currentVerbList.Add("marchitar");
            currentVerbList.Add("marearse");
            currentVerbList.Add("medir");
            currentVerbList.Add("mejorar");
            currentVerbList.Add("mendigar");
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
            currentVerbList.Add("optar");
            currentVerbList.Add("organizar");
            currentVerbList.Add("orinar");
            currentVerbList.Add("otorgar");
            return currentVerbList;
        }

        public List<string> GetPVerbList()
        {
            var currentVerbList = new List<string>();
            currentVerbList.Add("pagar");
            currentVerbList.Add("parar");
            currentVerbList.Add("parecer");
            currentVerbList.Add("parir");
            currentVerbList.Add("parlar");
            currentVerbList.Add("partir");
            currentVerbList.Add("pasar");
            currentVerbList.Add("patear");
            currentVerbList.Add("patinar");
            currentVerbList.Add("pedir");
            currentVerbList.Add("pegar");
            currentVerbList.Add("peinar");
            currentVerbList.Add("pensar");
            currentVerbList.Add("perder");
            currentVerbList.Add("permitir");
            currentVerbList.Add("pesar");
            currentVerbList.Add("pescar");
            currentVerbList.Add("pillar");
            currentVerbList.Add("pisar");
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
            currentVerbList.Add("proporcionar");
            currentVerbList.Add("proteger");
            return currentVerbList;
        }

        public List<string> GetQVerbList()
        {
            var currentVerbList = new List<string>();
            currentVerbList.Add("quedar");
            currentVerbList.Add("quemar");
            currentVerbList.Add("querer");
            currentVerbList.Add("quitar");
            return currentVerbList;
        }

        public List<string> GetRVerbList()
        {
            var currentVerbList = new List<string>();
            currentVerbList.Add("realizar");
            currentVerbList.Add("recargar");
            currentVerbList.Add("recibir");
            currentVerbList.Add("recoger");
            currentVerbList.Add("reconcilar");
            currentVerbList.Add("reconocer");
            currentVerbList.Add("recordar");
            currentVerbList.Add("recorrer");
            currentVerbList.Add("recostar");
            currentVerbList.Add("regalar");
            currentVerbList.Add("regresar");
            currentVerbList.Add("rehacer");
            currentVerbList.Add("rendir");
            currentVerbList.Add("renovar");
            currentVerbList.Add("reparar");
            currentVerbList.Add("repartir");
            currentVerbList.Add("repetir");
            currentVerbList.Add("resaltar");
            currentVerbList.Add("responder");
            currentVerbList.Add("retrasar");
            currentVerbList.Add("rezar");
            currentVerbList.Add("rodar");
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
            currentVerbList.Add("sanar");
            currentVerbList.Add("secar");
            currentVerbList.Add("seguir");
            currentVerbList.Add("sembrar");
            currentVerbList.Add("sentar");
            currentVerbList.Add("sentir");
            currentVerbList.Add("ser");
            currentVerbList.Add("servir");
            currentVerbList.Add("soler");
            currentVerbList.Add("soltar");
            currentVerbList.Add("soplar");
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
            currentVerbList.Add("tramar");
            currentVerbList.Add("tratar");
            currentVerbList.Add("trepar");
            currentVerbList.Add("tumbar");
            return currentVerbList;
        }

        public List<string> GetUVerbList()
        {
            var currentVerbList = new List<string>();
            currentVerbList.Add("ubicar");
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
            currentVerbList.Add("vetar");
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