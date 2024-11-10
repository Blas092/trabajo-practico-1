using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorDeNivel : MonoBehaviour
{
    [Header("Platform Settings")]
    public GameObject plataformaPrefab;  // Prefab de la plataforma a instanciar
    public float distanciaEntrePlataformas = 5f; // Distancia horizontal entre plataformas
    public int plataformasPorPantalla = 5; // Número de plataformas visibles en pantalla

    private Transform jugadorTransform; // Transform del jugador para seguir su posición
    private List<GameObject> plataformas; // Lista para almacenar las plataformas
    private float ultimaPosicionX; // Última posición en X donde se generó una plataforma

    private void Start()
    {
        jugadorTransform = GameObject.FindGameObjectWithTag("Player").transform;
        plataformas = new List<GameObject>();

        // Genera plataformas iniciales
        for (int i = 0; i < plataformasPorPantalla; i++)
        {
            GenerarPlataforma(new Vector2(i * distanciaEntrePlataformas, -1)); // Coloca la primera plataforma
        }
        ultimaPosicionX = plataformas[plataformas.Count - 1].transform.position.x;
    }

    private void Update()
    {
        // Generar nuevas plataformas a medida que el jugador avanza
        if (jugadorTransform.position.x > ultimaPosicionX - (plataformasPorPantalla * distanciaEntrePlataformas))
        {
            GenerarPlataforma(new Vector2(ultimaPosicionX + distanciaEntrePlataformas, Random.Range(-1f, 1f)));
        }

        // Elimina las plataformas que quedaron muy atrás
        if (plataformas.Count > plataformasPorPantalla * 2)
        {
            Destroy(plataformas[0]);
            plataformas.RemoveAt(0);
        }
    }

    private void GenerarPlataforma(Vector2 posicion)
    {
        GameObject nuevaPlataforma = Instantiate(plataformaPrefab, posicion, Quaternion.identity);
        plataformas.Add(nuevaPlataforma);
        ultimaPosicionX = posicion.x;
    }
}