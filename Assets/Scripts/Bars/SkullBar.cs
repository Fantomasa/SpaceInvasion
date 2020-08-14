using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkullBar : MonoBehaviour
{
    [SerializeField] private RectTransform barMask = default;
    [SerializeField] private RectTransform glowImg = default;
    [SerializeField] private RawImage barRawImage = default;

    private SkullMana skullMana;
    private float barMaskWidth;

    private float change = 6;

    public void Awake()
    {
        barMaskWidth = barMask.sizeDelta.x / change;
    }

    private void Start()
    {
        skullMana = new SkullMana();
    }

    private void Update()
    {
        skullMana.Update();
        AnimateRawImage();

        UpdateMaskSize();

        AddMana();

    }

    public void AddBarMaskWidth()
    {
        if (change - 1 >= 1) change--;
    }

    private void CheckDestroyBar()
    {
        if (Mathf.Floor(skullMana.ManaAmount) <= 0f)
        {
            Destroy(this.gameObject);
        }
    }

    private void AnimateRawImage()
    {
        Rect uvRect = barRawImage.uvRect;
        uvRect.x += 0.5f * Time.deltaTime;
        barRawImage.uvRect = uvRect;
    }

    private void UpdateMaskSize()
    {
        Vector2 barMaskSizeDelta = barMask.sizeDelta;
        barMaskSizeDelta.x = skullMana.GetManaNormalized() * barMaskWidth;
        barMask.sizeDelta = barMaskSizeDelta;

        glowImg.anchoredPosition = new Vector2(-skullMana.GetManaNormalized() * barMaskWidth, 0);
    }

    public void AddMana()
    {
        skullMana.AddMana(0.2f);
    }
}

public class SkullMana
{
    private int maxMana = 100;
    private float manaAmount;

    public SkullMana()
    {
        manaAmount = 0;
    }

    public int MaxMana
    {
        get { return maxMana; }
        set
        {
            if (value <= 100)
            {
                maxMana = value;
            }
        }
    }

    public float ManaAmount
    {
        get { return this.manaAmount; }
        set
        {
            if (value >= 0 && value <= maxMana)
            {
                this.manaAmount = value;
            }
        }
    }

    public void Update()
    {
        manaAmount = Mathf.Clamp(manaAmount, 0f, maxMana);
    }

    public void AddMana(float amount)
    {
        ManaAmount += amount;
    }

    public float GetManaNormalized()
    {
        return manaAmount / maxMana;
    }
}
