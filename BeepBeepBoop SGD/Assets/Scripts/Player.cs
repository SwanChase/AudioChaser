using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/* This class just makes it faster to get certain components on the player. */

public class Player : MonoBehaviour
{

    #region Singleton

    public static Player instance;

    void Awake()
    {
        instance = this;
    }

    #endregion

    public int score;
    private int m_MyVar = 0;
    public int MyVar
    {
        get { return m_MyVar; }
        set
        {
            if (m_MyVar == value) return;
            m_MyVar = value;
            if (OnVariableChange != null)
                OnVariableChange(m_MyVar);
        }
    }
    public delegate void OnVariableChangeDelegate(int newVal);
    public event OnVariableChangeDelegate OnVariableChange;

}