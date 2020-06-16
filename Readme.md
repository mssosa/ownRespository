Instrucciones de USO
=

1.	Utilizar la dirección base de la api

    a.	Para acceder, la URL base es: https://melimssosa.azurewebsites.net/

2.	Realizar una petición según:

Se pueden utilizar 2 funciones diferentes (mediante los métodos POST y GET)

  a. Por POST

            Con esta petición podremos ingresar un ADN y verificar si es humano o no

        i.	Ingresaremos a verificar si un humano es mutante o no
          2.  URL: https://melimssosa.azurewebsites.net/mutant/
          3.  Pasar por parámetro un array de string dna en formato JSON:
          4.  Ejemplo:

             {"dna": ["ATGCGA", "CAGTGC", "TTATGT", "AGAAGG","CCCCTA","TCACTG"]}
             //nos retornará StatusCode 200 --> SI es mutante
      
      5.  Se puede obtener por respuesta 3 opciones
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

