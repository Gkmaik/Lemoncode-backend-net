# Parte opcional
He añadido al diagrama de la parte obligatoria las tablas JerarquíaNiv1, JerarquíaNiv2, JerarquíaNiv3, UsuarioRegistrado y Subscripción. Las nuevas relaciones que he pensado son las siguientes:
* Un Curso puede tener varios Usuarios registrados, y a su vez, varios Usuarios registrados
* Un Usuarios registrado puede tener una subscripción, y a su vez, un plan de Subscripciones tendrá una lista de usuarios que la pagan
* Un Área puede tener una Jerarquía de más alto nivel (ej. FrontEnd), y opcionalmente tener otra de más bajo nivel (ej. Angular) e incluso un tercer nivel (ej. Testing). 
  
![Portal_ELearning_Opcional drawio](https://github.com/Gkmaik/Lemoncode-backend-net/assets/164330643/299304fc-84a0-4a17-bf92-b43ba36eb8b1)
