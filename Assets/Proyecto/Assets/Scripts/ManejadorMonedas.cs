using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.CorgiEngine;
using MoreMountains.Tools;

public class ManejadorMonedas:MonoBehaviour, MMEventListener<PickableItemEvent>
{
    private int monedas_recolectadas;

    void OnEnable()
    {
        this.MMEventStartListening<PickableItemEvent>();
    }
    void OnDisable()
    {
        this.MMEventStopListening<PickableItemEvent>();
    }

    public virtual void OnMMEvent(PickableItemEvent e)
    {
        Debug.Log(e.PickedItem.name);
    }

}
