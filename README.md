

Ortiga Games

Documento de Diseño

21 de septiembre de 2022

Versión Alfa





Índice

**Índice**

**2**

**1. Cambios entre las versiones**

**4**

1.1 Versión alfa - 0.X.Xf

4

**2. Introducción**

2.1 Título

**5**

5

5

5

6

6

6

6

7

7

2.2 Estudio y desarrolladores

2.3 Plataforma

2.4 Versión

2.5 Sinopsis

2.6 Género

2.7 Mecánica

2.8 Tecnología

2.9 Público

**3. Mecánicas del juego**

3.1 Cámara

**8**

8

8

9

9

3.2 Controles

3.3 Puntuación

3.4 Guardar/Cargar

**4. Estados del juego**

**9**

**5. Interfaz**

**10**

10

11

5.1 Interfaz de combate

5.2 Interfaz de mejora

**6. Niveles del juego**

**12**

12

13

13

14

6.1 El ataque de los himenopios

6.2 El asedio del abismo de Keus

6.3 Desparasitando que es gerundio

6.4 El jefe final

**7. Personajes del jugador**

PROTAGONISTA

**15**

21

21

7.1 Sprites en combate

**8. Enemigos**

**22**

22

23

23

24

8.1 El ataque de los himenopios

8.2 El asedio del abismo de Keus

8.3 Desparasitando que es gerundio

8.4 Jefe Final





**9. Música y Sonido**

**25**

**25**

**26**

**10. Detalles de producción**

**Business Canvas Model**





1.Cambios entre las versiones

1.1 Versión alfa - 0.X.Xf

● Se ha cambiado el nombre de “Project: Space” a “How the Heck do I

Become a Space Captain?!” - 0.1.1f

● Se ha decidido que el número de aliados sea 6 - 0.1.2f

● Se ha decidido que el juego tiene 6 fases - 0.1.3f

● Se ha optado por eliminar la parte de gestión de recursos para

centrarse en el componente de estrategia - 0.2.1f

● Se ha cambiado de un tablero de ajedrez a un tablero hexagonal -

0.2.2f

● Se ha establecido que el número de niveles serán 4 - 0.2.3f

● Se ha dado a cada nivel objetivos distintos para dar variedad al juego -

0.3.1f





2.Introducción

2.1 Título

El título del videojuego sería “How the Heck do I Become a Space

Captain?!” HTHDIBSC, para abreviar dentro del documento.

2.2 Estudio y desarrolladores

Ortiga Games formado por:

\-

\-

\-

\-

\-

Jesús Culebras González:

● Project Manager

● Programador

Laura Fouz García:

● Concept artist

● Diseñador de personajes.

Aitor Lebrero Barroso:

● Concept artist

● Diseñador de escenarios.

Elena Lopez-Negrete Burón:

● Community manager

● Programador

Marcos Toledo Sánchez:

● Programador

2.3 Plataforma

Será un juego desarrollado para navegadores web, haciendo uso de WebGL

para renderizar el juego. Por lo tanto, cualquier dispositivo con acceso a un

navegador compatible con WebGL podrá disfrutar del título.





2.4 Versión

Este documento se centra en la versión Alfa del título, constante de un

prototipo jugable y estable que representa las principales mecánicas del título.

2.5 Sinopsis

“Tú y tu escuadrón habéis sido seleccionados para realizar el examen oficial

de la Federación Especial que te calificará como apto para convertirte en capitán

espacial oficial y poder salir en misiones para proteger la galaxia. El examen

consiste en dirigir a unas simulaciones computacionales de tu equipo a lo largo de

distintas misiones que representan la mayoría de misiones que encontraréis como

equipo oficial de la Federación.”

2.6 Género

HTHDIBSC se trata de un juego de estrategia por turnos en un sistema de

tablero con casillas, similar al que se encuentra en títulos como “Fire Emblem” o

“XCOM”.

2.7 Mecánica

El juego se dividirá en 4 fases, que representarán las distintas pruebas que

constituyen el examen de la federación y cada una tendrá sus propios objetivos y

peculiaridades (Derrotar a todos los enemigos, evitar que los enemigos huyan del

mapa, defender una posición durante un determinado número de turnos…). Para

lograr dichos objetivos, el jugador deberá dirigir a sus unidades por el tablero de

juego, compuesto por una matriz de 30 casillas por 30 casillas, mediante clicks del

ratón. Una vez la misión sea completada, los jugadores obtendrán una recompensa

en forma de créditos y pasarán a la pantalla de mejora de unidades; en la que

podrán subir las distintas características de los personajes (Vida, ataque,

defensa…), a partir de ahí podrán elegir si quieren rejugar un nivel para obtener más

créditos o pasar a la siguiente fase. La dificultad de los enemigos irá escalando

durante los niveles, haciendo necesaria la mejora de personajes para tener una





partida con una dificultad óptima, aunque esto permitirá que los jugadores hagan

partidas en modo “difícil” sin mejorar ninguna unidad.

2.8 Tecnología

La plataforma de desarrollo escogida, ha sido Unity en su versión 2021.3.10,

al ser esta la última versión, a momento de creación del documento, LTS del motor,

además de que permite acceso a herramientas como Shader Graph para la creación

de shaders gráficos sin necesidad de acceder a la URP o la HDRP, que podrían

bajar el rendimiento del juego ya que WebGL no ofrece soporte para estos

paradigmas de renderizado.

2.9 Público

HTHDIBSC está enfocado a un nicho de mercado concreto: el de los

jóvenes de hasta 30 años que usen de forma rutinaria redes sociales y sean parte

de la cultura "fandom" de internet, y que sean o bien consumidores, creadores o

ambos tanto de "fanfictions" como "fanarts" (entre otros colectivos como el LGTB,

por ejemplo), ya que pretendemos que se cree un fandom potente y activo de

nuestro juego que lo mantenga vivo. Para ello nos apoyaremos en personajes muy

carismáticos y con diseños llamativos para que los jugadores se puedan sentir

identificados con ellos. Por esta razón hemos creado también una serie de

relaciones y dinámicas entre dichos personajes basados en tropos muy queridos y

aclamados por los distintos fandoms que hemos estudiado, añadiendo una pequeña

vuelta de tuerca a las mismas para no ser repetitivos y llamar la atención, esta

información le llegaría a los usuarios a través de pequeños cómics, animáticas o

memes que se publicaría en la cuenta oficial de la empresa. Todo esto, junto con

una serie de actualizaciones que se irían realizando en fechas clave (Navidad,

Halloween...), ayudarán a mantener la comunidad del juego activa y fomentará la

publicidad boca a boca, que en este tipo de nichos es muy potente.





3.Mecánicas del juego

3.1 Cámara

La cámara en HTHDIBSC, durante las fases de combate, estará situada en

un ligero ángulo picado respecto al tablero, para facilitar la visión del mapa

completo, la cámara se podrá mover arrastrando el ratón y al clickar en una unidad,

está se centrará en dicha unidad. Durante las pantallas de mejora la cámara estará

estática en un ángulo frontal enfocando retratos del personaje que se esté

mejorando.

3.2 Controles

El juego está pensado para ser manejado en su totalidad con el ratón, la

razón de esto es la generación de un esquema de controles simple e intuitivo que

sea fácilmente traducible a un esquema de control en dispositivos móviles, por ello,

los controles en navegador tienen un símil directo con gestos que admite la pantalla

táctil de un móvil (“pinchar” en iconos, arrastrar el dedo por la pantalla para

desplazarse…)





3.3 Puntuación

La puntuación será representada por los créditos que se obtengan al final de

la partida, estos irán en función del rendimiento que tenga el jugador en cada fase

(Los requisitos para determinar el rendimiento variarán en función de la fase, por

ejemplo: Cuántos turnos se han empleado en completar el nivel, las unidades que

se han perdido…). Estos “puntos” son clave ya que es la divisa que permitirá al

jugador mejorar sus unidades y facilitarle los niveles más complejos del juego.

3.4 Guardar/Cargar

El jugador podrá guardar su progreso en cualquier momento siempre que se

encuentre en el menú de mejora o de selección de nivel.

4.Estados del juego

En el siguiente diagrama se puede observar una representación de los

distintos estado en los que se puede encontrar el juego, además de los flujos entre

los mismos:





5.Interfaz

Las dos interfaces más importantes y representativas del título serían la

interfaz que se muestra durante los combates y la del menú de mejora de

personajes. A continuación se dará más detalle sobre el aspecto de estas interfaces.

5.1 Interfaz de combate

Esta interfaz, es de las más

importantes del juego, ya que

muestra toda la información clave

para el desarrollo del combate.

Aparecerá al hacer click sobre un

una unidad y mostrará las casillas

a las que se puede desplazar

dicho personaje resaltándolas en

color verde, mientras que las que

estén ocupadas por enemigos

serán rojas. Si mientras el jugador tiene seleccionado un aliado clicka sobre un

enemigo en su rango de ataque, las casillas en las que debe colocarse para poder

atacarle estarán resaltadas en azul y las casillas ocupadas por un aliado estarán

resaltadas en amarillo. Mostrará también un resumen de las estadísticas del

personaje elegido y un pequeño retrato del personaje, además de las distintas

habilidades que posea el personaje y la acción de atacar. Aparecerá también un

botón que permita cancelar la acción sin malgastar el turno y cambiar de personaje.





5.2 Interfaz de mejora

Está será la interfaz que verán los

jugadores al terminar un nivel. Muestra

un retrato del personaje con unas

flechas para ir pasando entre ellos. A la

derecha se muestra su nombre, sus

estadísticas y un pequeño fragmento de

historia del personaje. Incluye también

un botón que dirige al jugador a la

pantalla de guardado o al menú

principal. Por último tiene un botón que

manda al jugador a la pantalla de selección de nível.





6.Niveles del juego

6.1 El ataque de los himenopios

Este es el primer nivel del juego y el que

será implementado en el prototipo.

En esta misión el equipo del jugador será

desplegado en una región boscosa del

planeta de uno de los miembros del equipo;

Declan. La Federación necesita que se

neutralice a un grupo de himenopios (una

especie nativa del planeta y que se parecen

a mantis orquídeas) agresivos.

Para completar este nivel simplemente

habría que derrotar a todos las unidades

enemigas que haya en el mapa. Al estar el

nivel situado en un bosque, el equipo tendrá

que intentar maniobrar en torno a los árboles

gigantes que crecen en ese entorno y al que

los himenopios están acostumbrados. En

este nivel podremos encontrar dos tipos de enemigos: los que atacan a distancia y

los que lo hacen cuerpo a cuerpo. El equipo del jugador, formado por 6 personajes

deberá enfrentarse a un grupo de 15 himenopios.





6.2 El asedio del abismo de Keus

La segunda fase del juego.

En este nivel, el escuadrón deberá

defender el sector este de la ciudad

colonial de Keus de un asedio de

unos enemigos devoradores de

mundos. La ciudad de Keus está

situada en un planeta desértico y

montañoso, muy importante para la

Federación por sus recursos

minerales. El objetivo de esta fase es mantener al enemigo a raya durante un

número determinado de turnos mientras se activan los campos de fuerza de la

ciudad. Durante esta fase no dejarán de aparecer enemigos hasta que se acabe el

límite de 10 turnos.

6.3 Desparasitando que es gerundio

Este nivel tiene lugar en una nave

de la Federación infestada por

unas formas de vida alienígenas

parasitarias. La misión del equipo

es eliminar a todos los parásitos

que han infectado la nave antes de

que huyan e infecten otra nave o

planeta. Los enemigos en este

mapa se moverán rápido y la

estrategia será clave para

completar este nivel sin problemas.





6.4 El jefe final

Esta sería la última fase del juego. En ella

el equipo del jugador ha sido mandado a

acabar con una misteriosa forma de vida

alienígena que ha formado un nido en unas

antiguas ruinas. El objetivo de este nivel es

derrotar al jefe. Este enemigo no podrá

moverse, sin embargo esto no lo hará más

sencillo dada su gran barra de salud y

poder de ataque, además, el enemigo irá

spawneando súbditos, que aunque sean débiles pueden abrumar al jugador si no se

encarga de ellas rápidamente. El objetivo de este nivel es poner a prueba el

conocimiento del jugador sobre sus unidades, no se podrá ganar sin estrategia.

Se tiene pensado, también, desarrollar niveles temáticos para distintas

fechas especiales como Halloween o Navidad con cambios estéticos en los

personajes (disfraces de monstruos para Halloween, de Papá Noel para Navidad…)





7.Personajes del jugador

**DECLAN**

**Vida:** 35 **Defensa:** 5 **Ataque:** 5 **Velocidad:** 8

**Rango de movimiento:** 5 casillas **Rango de alcance:** 2 casillas

**Trasfondo:** Mercenario seta que proviene de

un planeta boscoso. Los mercenarios de su

especie son muy solicitados por los capitanes

gracias a los diferentes poderes de sus esporas.

Normalmente suelen trabajar con el mejor postor,

pero a Declan le llamó la atención la peculiar

tripulación del protagonista y decidió unirse a ella

por pura curiosidad, aunque la paga fuera mínima.

Es un chico sarcástico y debido a la expresión

neutra de su cara puede parecer antipático pero

realmente es muy buena persona y generoso con

sus compañeros, aunque no soporta a Norbert.

**Apariencia física:** Cabeza con forma de seta,

cuerpo esbelto y alto, mide 2.15 metros y siempre

lleva una planta blanda procedente de su planeta

en la boca que muerde a veces como antiestrés.

**Estilo de combate:** Ataca con esporas

venenosas u ofrece un turno extra a un compañero

a elegir gracias al potenciador de sus esporas.





**NASS**

**Vida:** 40 **Defensa:** 10 **Ataque:** 5 **Velocidad:** 2

**Rango de movimiento:** 3 casillas **Rango de alcance:** 1 casilla

**Trasfondo:** Es un alien que era usado

para torneos de lucha ilegales por un

hombre que le encontró abandonado en un

callejón, desde que era niño llevaba

máscaras y ropa que ocultaba todo su

cuerpo pues según el hombre, su apariencia

era grotesca y le daban ganas de vomitar

solo de verla, por ello siempre se niega a

mostrar su rostro actualmente.

El protagonista fue a uno de los torneos en

busca de alguien fuerte y resistente, allí

encontró al alien y este aceptó, se metió en

un traje de astronauta abandonado y se unió

al equipo con una nueva identidad y un

nuevo nombre sacado de la etiqueta del

traje, NASS.

NASS representa el tópico de gigante con

corazón de oro, puede intimidar debido a

sus proporciones y su rostro oculto pero no

podrás encontrar criatura más amable y

buena en el universo.

**Apariencia física:** Alien de especie desconocida oculto dentro de un traje de

astronauta de 2.63 metros con un agujero en el casco que fue por donde accedió al traje.

Tiene un bolsillo en la parte frontal del traje donde guarda tentempiés, la mayoría golosinas,

para ofrecerlos a quien los necesite.

**Estilo de combate:** Ataca cuerpo a cuerpo con sus manos o puede ponerse en

posición de defensa para subir su defensa durante un turno.





**WINNIE**

**Vida:** 30 **Defensa:** 5 **Ataque:** 5 **Velocidad:** 5

**Rango de movimiento:** 4 casillas **Rango de alcance:** 2 casillas

**Trasfondo:** Winnie siempre quiso ser una

exploradora espacial. Su familia contaba con

innumerables recursos y dinero, y proporcionaban

a la chica de cualquier equipamiento que

necesitara. Durante años exploró el espacio como

turista, sin llegar a experimentar verdadero peligro.

Su pasión siempre fue encontrar lugares recónditos

y ayudar a aquellos que lo necesitaran por el

camino, siempre con ropa espacial bonita y con

una sonrisa en la cara.

Al cabo de un tiempo empezó a aprender que lo

que quería debía ganárselo sin ayuda de nadie, y

usó su experiencia para volverse una exploradora

independiente. Sus intenciones siempre fueron

puras y, aunque ahora se avergüenza de cómo era,

nunca dejó atrás el brillo y los conjuntos

coordinados. Ahora le acompaña el pequeño

Calamari, un alien muy juguetón que encontró en

una de sus misiones en solitario.

**Apariencia física:** Joven humana, mide 1.66 metros, lleva ropa colorida con un

estilo espacial, tiene los ojos color violeta y el pelo largo y rubio

**Estilo de combate:** Dispara con su pistola láser o manda a Calamari para que cure

a un aliado 1 punto de vida cada turno





**CAROLINE**

**Vida:** 20 **Defensa:** 1 **Ataque:** 10 **Velocidad:** 5

**Rango de movimiento:** 4 casillas **Rango de alcance:** 3 casillas

**Trasfondo**: Esta criatura anfibia puede

parecer un tanto simple de mente, y

efectivamente, lo es. Caroline era un pez rojo

de pecera llamado burbu, cuya existencia se

basaba en nadar en círculos y comer lo que

caía de la superficie del agua, hasta que un

científico llamado Gerónimo le introdujo una

serie de sueros para hacer que desarrollase un

cuerpo antropomorfo y ciertas emociones

complejas. Vivía en un tanque en el sótano de

Gerónimo, hasta que este fue frenado por el

equipo espacial. Los demás querían liberarla

en un lago de la tierra, pero Winnie insistió en

que se la quedaran. Caroline pronto se ganó el

cariño de todos los tripulantes, y demostró ser

de mucha ayuda en el campo de batalla,

manejando las armas pesadas con

sorprendente precisión. A día de hoy no sabe

hablar, y se comunica con simples gestos, pero

es la favorita de Winnie.

**Apariencia física**: Criatura basada en un pez, mide 1.75 metros, tiene el pelo tan largo que

llega a ser arrastrado por el suelo y viste con un traje de buzo.

**Estilo de combate**: Dispara con su bazuca





**NORBERT**

**Vida:** 25 **Defensa:** 4 **Ataque:** 4 **Velocidad:** 10

**Rango de movimiento:** 3 casillas **Rango de alcance:** 2 casillas

**Trasfondo:** Sus padres eran

exploradores que se dedicaban a recolectar

objetos que encontraban para luego venderlos

en el mercado. Murieron en una explosión

durante una de sus expediciones cuando

Norbert tenía 15 años, dejándole solo con su

hermana robot G470.

Norbert intentó ganarse la vida haciendo lo

mismo que sus padres junto con G470, pero

solo encontraban chatarra. Comenzaron a

saquear y robar componentes de naves por

los que conseguían lo suficiente para

sobrevivir en el mercado negro.

En uno de sus saqueos, cuando ya estaban

listos para irse con todo, Norbert vio a un alien

seta y, sabiendo lo valiosas que son sus

esporas, actuó sin pensar, segundos después,

se levantó atado a un poste con G470 y una

persona a su lado ofreciéndoles unirse a su

tripulación. A día de hoy, Declan sigue sin

aprobar esa decisión.

Norbert es muy despreocupado y extrovertido,

no tiene modales y se aburre con facilidad.

**Apariencia física:** Es un hombre humano descuidado y esbelto que mide 1.94

metros, se corta él mismo el pelo y lo tiene alborotado, tiene una cicatriz en la nariz y lleva

una cadena de su madre en el cuello y ropa desgastada.

**Estilo de combate:** Dispara con sus dos pistolas, como es ágil tiene un turno extra.





**G470**

**Vida:** 28 **Defensa:** 3 **Ataque:** 1 **Velocidad:** 5

**Rango de movimiento:** 4 casillas **Rango de alcance:** 2 casillas

**Trasfondo:** Robot construido por la

madre de Norbert para cuidarle y hacerle

compañía durante su ausencia. La construyó

con rasgos felinos pues Norbert siempre quiso

un gato de mascota cuando era pequeño pero

debido a la alergia de su madre nunca pudo

tenerlo.

A ella nunca le ha gustado vivir como

delincuentes y solo quiere que Norbert sea

feliz y tenga una buena vida. Ella fue quien

terminó convenciendo a Norbert de aceptar la

oferta del protagonista para unirse a su

tripulación.

Es la más responsable y sabia del equipo, si

alguien tiene una pregunta sobre algún dato,

siempre acudirá a G470, aunque Winnie solo

puede preguntar 5 al día.

**Apariencia física:** Es un robot con rasgos felinos que mide 1.4 metros. Su cara es

una pantalla que cambia de expresiones formadas con letras y signos según su estado de

ánimo

**Estilo de combate:** Ataca con sus zarpas o cura 1/5 de la vida de G470 a un aliado

a elegir por turno.





**PROTAGONISTA**

Trasfondo: En el juego no se menciona nada del protagonista, solo se sabe que es

capitán de la tripulación y aspirante a ser un capitán oficial, es el que realiza el exámen, no

tiene una personalidad definida ni habla pues representa al propio jugador.

Apariencia física: No tiene apariencia física, es un juego en primera persona y solo

se ve la pantalla del ordenador.

7.1 Sprites en combate

**Declan**

**NASS**

**Winnie**

**Caroline**

**Norbert**

**G470**





8.Enemigos

8.1 El ataque de los himenopios

Los enemigos del primer nivel son los himenopios, una especie alienígena

similar a las mantis en aspecto. Tienen dos razas, una basada en las mantis

orquídea que luchan cuerpo a cuerpo con sus prominentes garras, y otra con garras

pegajosas e inutilizadas que combate a distancia lanzando las protuberancias que

crecen en su cola que explotan como bombas.

Sprites en combate:





8.2 El asedio del abismo de Keus

En este nivel se partió del concepto de unos seres de otro mundo que viajan

por el universo devorando toda la vida de los planetas que encuentran.

8.3 Desparasitando que es gerundio

En este nivel los enemigos son criaturas parasitarias pequeñas y rápidas.

Se alimentan de todo lo que encuentran a su paso abriendo su cuerpo y envolviendo

entre varias tanto a objetos como a seres vivos. Se adhieren con una sustancia

pegajosa y ácida de su cuerpo a la superficie de la que se están alimentando y la

van desintegrando poco a poco. Es uno de los parásitos más odiados.

Tienen encima una falsa cabeza con una boca enorme que usan para asustar a

posibles amenazas.





8.4 Jefe Final

El concepto que se utilizó para este enemigo era el de una criatura que llegó

a unas ruinas y comenzó a construirse una armadura o esqueleto con componentes

que encontró en el sitio y formó allí su colmena.





9.Música y Sonido

La banda sonora será compuesta utilizando el software Bosca Ceoil y

deberá adaptarse a cada nivel. Se van a componer las siguientes canciones:

● Canción de menú principal

● Canción de selección de nivel

● Canción de pantalla de mejora

● Canción de nivel 1

● Canción de nivel 2

● Canción de nivel 3

● Canción de nivel 4

● Canción de victoria

● Canción de derrota

\10. Detalles de producción

Fecha de inicio de la versión alfa - 21-09-2022

Fecha de finalización de la versión alfa - 30-10-2022





Business Model Canvas





Toolkit

