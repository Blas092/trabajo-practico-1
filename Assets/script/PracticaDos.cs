using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PracticaDos : MonoBehaviour
{
    // Función que recibe tres parámetros y retorna un string con el resultado
    public string CompararValores(float valor1, float valor2, float valor3)
    {
        // Determina el mayor y el menor de los tres valores
        float mayor = Mathf.Max(valor1, valor2, valor3);
        float menor = Mathf.Min(valor1, valor2, valor3);

        // Comprobar si el mayor es superior a 100
        if (mayor > 100)
        {
            return "Mayor fuera de rango";
        }

        // Comprobar si el menor es inferior a 0
        if (menor < 0)
        {
            return "Menor fuera de rango";
        }

        // Si ninguno de los valores supera los umbrales, calcular y devolver el promedio
        float promedio = (valor1 + valor2 + valor3) / 3;
        return "El valor promedio es: " + promedio;
    }

    
    void Start()
    {
        // Llamar a la función CompararValores con tres valores de ejemplo
        string resultado = CompararValores(50.5f, 20.3f, 101.7f);
        Debug.Log(resultado);  // Muestra el resultado en la consola de Unity
    }

    // Método Start donde generamos los valores aleatorios y llamamos a la función
    
    } 