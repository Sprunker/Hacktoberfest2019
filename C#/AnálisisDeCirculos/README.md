### Análisis de Imagen (Detección de Círculos) ###

Este programa ayuda a detectar círculos en una imagen (no son válidas las elipses ni donas).
Está hecho para el ambiente visual, incluye la definición del objeto círculo, y una clase llamada Process la cual nos ayudará al procesamiento de la imagen en un bitmap.
Los recursos que se trabajan son los siguientes:
*Bitmap: Aquí almacenaremos la imagen para después hacer el análisis pixel por pixel.
*OpenFileDialog: Para abrir la ruta de acceso de la imagen.
*PictureBox: Herramienta que nos ayudará a almacenar y mostrar la imagen.
*Lista: Para almacenar los círculos encontrados.
*Color: Para determinar el color de los círculos (En este caso serán negros, pero se puede modificar al gusto).
*System.Drawing: Librería que nos ayudará a pintar círculos para el tratado de imagen.
*Grapich: Objeto que nos ayudará a pintar sobre un bitmap.
*Brush: Objeto Brocha para pintar.
*ListBox: Para almacenar los datos de los círculos.

### A tomar en cuenta ###

En mi caso utilizolos siguiente en la ventana principal:
*Dos pictureBox's para el antes y el después.
*Un listBox para el almacenamiento de la información de los círculos encontrados.
*Dos botones: Uno para abrir la imagen y otro para iniciar el análisis de la imagen.

** El código está comentado para la fácil comprensión **