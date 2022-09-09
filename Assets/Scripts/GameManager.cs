using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI textMarcador1;
    public TextMeshProUGUI textMarcador2;
    public BallController ballController;

    private void Start()
    {
        // Se inscribe el GameManager al evento OnGoal
        ballController.OnGoal += BallController_OnGoal;
    }

    private void BallController_OnGoal(object sender, System.EventArgs e)
    {
        Debug.Log("GOOOOL");
    }
}
