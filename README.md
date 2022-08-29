# README
> Creado el 30 - 08 - 2022

## Effectors2D
> https://docs.unity3d.com/Manual/Effectors2D.html
Librería que contiene efectos útiles diversos para aplicar directamente (Usado `Surface Effector 2D` en el GameObject `Level Sripte Shape`).

## Audio
- La cámara principal tiene un componente llamado `Audio Listener`, sin el no se podrá reproducir audio. 
- Cada gameObject puede tener varios componentes `Audio Source` y sirve para albergar y reproducir el audio, además de ajustar el volumen, etc. 
- `Audio Clip` es donde arrastramos el adio y puede ser del formato (mp3, Wav, OGG).
- Para reproducir un audio, lo hacemos desde el script. 

## Desactivar controles tras evento
En este juego cuando el jugador choca con la cabeza pierde pero seguimos controlándolo. Para evitar que lo controlemos creamos un método público dentro de `PlayerController.cs` que será invocado desde `CrashDetector.cs`. Básicamente, al tocar suelo con la cabeza desactiva el movimiento ejecutado desde el primer script.

## Ejecutar un evento una sola vez
Ocurre que cuando reproducimos nuestros audios cuando toca el suelo con la cabeza o cuando llega a la meta, estos audios se pueden reproducir más de una vez. Para garantizar que solo se reprodusca una vez debemos crear un booleano `hasCrashed` o algo así y comprobarlo en la colisión. Ejemplos en `FinishLine.cs` y `CrashDetector.cs`. 

## Particle System
> Right click on `Hierarchy` → `Effects` → `Particle System`.

> Se aconseja que las partículas siempre estén dentro de un GameObject vacío.

### Finish Effect
> Algunos de estos valores tienen una flecha al extremo derecho en donde podemos elegir qué tipo de valor ingresaremos.
Este módulo es el encargado de modificar el comportamiento de cada partícula por individual.
- Duration
- Looping
- Start Delay
- Start Lifetime
- Start Speed
- Start Size
- Start Color
- Gravity Modifier
- Play on Awake (Evita que el efecto aparezca ni bien empieza el juego)

### Emission
Este módulo se encarga de la cantidad de partículas que serán expulsadas.
- Rate over Time

### Shape
Módulo encargado de la forma de la partícula.
- Shape

### Noise
El ruido o desorden de las partículas.
- Strength

### Renderer
Módulo encargado de renderizar la partícula con un Sprite.
- Material
- Order in Layer


## Sprite Shape
En este juego el terreno ha sido generado por Unity partiendo de un sprite sencillo `Assets/Sprites/Snow-tile-low-res.png`. Se ha podido ajustar su forma y convertirlo en un terro creando un GameObject con Clic derecho → `2D Object` → `Sprite Shape` → `Closed Shape`.

> En el juego se renombró a: `Level Sprite Shape`

Luego tenemos que crear un `Profile` haciendo Clic derecho en la carpeta `/Sprites` → `Create` → `2D` → `Sprite Shape Profile`. Tiene muchas cosas para editar y que será mejor busques si quieres profundizar por otro sitio. Básicamente arrastramos nuestro sprite dentro de Sprites y en `Texture` nuestra textura llamada `blue-fill.png` también dentro de la carpeta Sprites. Arrastramos nuestro Profile en `Profile` dentro de nuestro `Sprite Shape Profile` creado anteriormente.

Debajo hay un icono y a su lado dice `Edit Spline`. Al hacer clic aparecen puntos para editar vectores. Si hacemos clic en la línea se crearán nuevos puntos y podemos ajustar la forma de nuestro terreno a nuestro gusto. Una vez terminado de editar volvemos a hacer clic en el icono. 

Al tratarse de una forma "extraña" para añadirle un collider debemos usar `Edge Collider 2D` que también podemos editar vectorialmente al hacer clic en el icono de `Edit Collider`. Pero si queremos ajustar el tamaño de colider como escalarlo, dentro de `Sprite Shape Controller (Script)` debajo en la sección `Collider` podemos jugar con el dial `Offset`.


