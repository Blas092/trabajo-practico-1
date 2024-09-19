using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.UI.Image;

public class PracticaDos : MonoBehaviour
{
    // Array inicial de 10 números enteros
    private int[] numeros = { 97, -64, -3, -58, -15, 58, 51, 38, -31, -37 };

    // Variable para el temporizador
    private float timer = 0f;

    // Tiempo de espera antes de modificar el array (4.5 segundos)
    private float tiempoDeEspera = 4.5f;

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

        // Imprimir el array original en la consola
        Debug.Log("Array inicial: " + string.Join(", ", numeros));

        // Llamar a la función CompararValores con valores aleatorios
        float valor1 = Random.Range(-100f, 100f);
        float valor2 = Random.Range(-100f, 100f);
        float valor3 = Random.Range(-100f, 100f);

        // Mostrar los valores generados
        Debug.Log("Valores generados: " + valor1 + ", " + valor2 + ", " + valor3);

        // Llamar a la función y mostrar el resultado
        string resultado = CompararValores(valor1, valor2, valor3);
        Debug.Log(resultado);
    }

    void Update()
    {
        // Incrementar el temporizador con el tiempo transcurrido desde el último frame
        timer += Time.deltaTime;

        // Comprobar si han pasado 4.5 segundos
        if (timer >= tiempoDeEspera)
        {
            // Llamar a la función para modificar el array
            ModificarArray();

            // Reiniciar el temporizador para evitar que se ejecute más de una vez
            timer = 0f;
        }
    }

    // Función que recorre el array y duplica los números pares
    void ModificarArray()
    {
        for (int i = 0; i < numeros.Length; i++)
        {
            // Si el número es par, lo duplicamos
            if (numeros[i] % 2 == 0)
            {
                numeros[i] *= 2;
            }
        }

        // Imprimir el array modificado en la consola
        Debug.Log("Array modificado: " + string.Join(", ", numeros));
    }

}