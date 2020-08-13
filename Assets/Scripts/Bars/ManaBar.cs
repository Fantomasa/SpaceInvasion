using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManaBar : MonoBehaviour
{
    [SerializeField] private RectTransform barMask = default;
    [SerializeField] private RectTransform glowImg = default;
    [SerializeField] private RawImage barRawImage = default;

    private Mana mana;
    private float barMaskWidth;

    public void Awake()
    {
        barMaskWidth = barMask.sizeDelta.x;
    }

    private void Start()
    {
        mana = new Mana();
    }

    private void Update()
    {
        mana.Update();
        AnimateRawImage();

        UpdateMaskSize();

        SpendMana();

        CheckDestroyBar();
    }

    private void CheckDestroyBar()
    {
        if (Mathf.Floor(mana.ManaAmount) <= 0f)
        {
            Destroy(this.gameObject);
        }
    }

    private void AnimateRawImage()
    {
        Rect uvRect = barRawImage.uvRect;
        uvRect.x -= 0.5f * Time.deltaTime;
        barRawImage.uvRect = uvRect;
    }

    private void UpdateMaskSize()
    {
        Vector2 barMaskSizeDelta = barMask.sizeDelta;
        barMaskSizeDelta.x = mana.GetManaNormalized() * barMaskWidth;
        barMask.sizeDelta = barMaskSizeDelta;

        glowImg.anchoredPosition = new Vector2(mana.GetManaNormalized() * barMaskWidth, 0);
    }

    public void SpendMana()
    {
        mana.SpendMana(0.2f);
    }

    public void RestoreMana()
    {
        mana.RestoreMana();
    }
}

public class Mana
{
    public const int MANA_MAX = 100;

    private float manaAmount;
    private float manaRegenAmount;

    public Mana()
    {
        manaAmount = 100;
        manaRegenAmount = 1f;
    }

    public float ManaAmount
    {
        get { return this.manaAmount; }
        set
        {
            if (value >= 0 && value <= MANA_MAX)
            {
                this.manaAmount = value;
            }
        }
    }

    public void Update()
    {

        manaAmount += manaRegenAmount * Time.deltaTime;
        manaAmount = Mathf.Clamp(manaAmount, 0f, MANA_MAX);
    }

    public void SpendMana(float amount)
    {
        if (manaAmount >= amount)
        {
            manaAmount -= amount;
        }
    }

    public float GetManaNormalized()
    {
        return manaAmount / MANA_MAX;
    }

    public void RestoreMana()
    {
        manaAmount = MANA_MAX;
    }
}
