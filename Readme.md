Instrucciones de USO
=

## 1.	Utilizar la dirección base de la api

    a.	Para acceder, la URL base es: https://melimssosa.azurewebsites.net/

## 2.	Realizar una petición según:

Se pueden utilizar 2 funciones diferentes (mediante los métodos POST y GET)

  a. Por POST

            Con esta petición podremos ingresar un ADN y verificar si es humano o no

              i.	Ingresaremos a verificar si un humano es mutante o no
             ii.  URL: https://melimssosa.azurewebsites.net/mutant/
            iii.  Pasar por parámetro un array de string dna en formato JSON:
  
               1.  Ejemplo:

                 {"dna": ["ATGCGA", "CAGTGC", "TTATGT", "AGAAGG","CCCCTA","TCACTG"]}
                 //nos retornará StatusCode 200 --> SI es mutante

              iv.  Se puede obtener por respuesta 3 opciones
                  1.	StatusCode 200 OK  La evaluación del ADN del humano ingresado dio por resultado POSITIVO. Es un mutante
                  2.	StatusCode 403 Forbiden  La evaluación del humano dio por resultado NEGATIVO, NO es un mutante
                  3.	StatusCode 400  Ocurrio un error en la solicitud


b.	Por GET

            Con este método podremos acceder a las estatidisticas

            i.	Para acceder a las ESTADISTICAS
            ii.	URL: https://melimssosa.azurewebsites.net/stats
            iii.	Obteniendo por respuesta en formato JSON
 
                 {

                “Count_mutant_dna” : 40,
                “Count_human_dna” :  100,
                “Ratio” : 0,4

                 }

 ## 3.	Tecnologías utilizadas:

        a.	C# con NetCore 3.1
        b.	Entity Framework 
        c.	RefSharp
        d.	SQL Server 2016
        e.	Visual Studio 2019
        f.	Postman
        g.	West Wind WebSurge

## 4.	Limitaciones
 
        a.	Esta alojado en un hosting gratuito de azure que no hay balanceo de carga.

## 5.	Para utilización Localhost:
 
        a. Descargar proyecto (desde clone o copiando el enlace)
        b. Instalar sotfware/librerías del punto 3.
        c. Es requisito tener instalado un SQL Server 2012 o superior.

              i. El nombre de la instancia del servidor debe ser SQLEXPRESS
             ii. En caso de tener OTRO nombre ir al “appsettings.json” o “appsettings.Development.json” que se encuentra en el proyecto MELI.WebApi y cambiar el valor del campo “MeliConeccion”, 
            iii. Por defecto el proyecto esta configurado para “PRODUCCION”

                  1. Para cambiarlo ir a las propiedades de MELI.WebApi

                      a. Click derecho en el proyecto MELI.WebApi
                      b. Propiedades
                      c. A la izquierda ir al menú de “Debug”
                      d. Visualizar la cuadrilla de Environment variables
                      e. Cambiar la variable ASPNETCORE_ENVIRONMENT que se encuentra en Production a Development.

        d. Compilar el proyecto MELI.WebApi.
           
        e. Ejecutar en la consola de Nuggets
        
             i. Para abrirla ir a Tools > Nugget Package Manager > Package Manager Console 
            ii. Ejecutar:


                            Update-database

                            /*Esto permitirá impactar la migración y crear la base de datos en el 
                            SQL Server. Por defecto utilizará las credenciales de Windows.*/


 
        f. Pulsar Ctrl + F5 para realizar un deploy al SQL Server Express con la cual se pueden correr TODOS los métodos de prueba
        g. Correr las pruebas desde el TestExplorer
 
               i. Para abrir el test explorer ir a View
              ii. Luego click en TestExplorer
 
                  1. En el se visualizarán todos los test disponibles y se pueden ejecutar desde la parte superior izquierda.
