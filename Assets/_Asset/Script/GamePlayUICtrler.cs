using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class GamePlayUICtrler : MonoBehaviour
{
    [SerializeField] StatisticCounting statisticCounting;
    [SerializeField] Image diamondCircle, diamondIcon;
    [SerializeField] SwitchColor[] switchColorImages;
    [SerializeField] TMP_Text magnetQuantity, rocketQuantity, x2Quantity,
        point, rank, pointToHighRank;
    [SerializeField] GameObject magnetButton, rocketButton, x2Button;
    PlayerData playerData;
    // Start is called before the first frame update

    private void Awake()
    {
        pointUpdate();
        statisticCounting.DoWhenPointIcrease += pointUpdate;
    }
    private void OnEnable()
    {
        if(playerData != null)
        {
            SetUpSkillQuantities();
        }
    }
    private void Start()
    {
        playerData = GamePlayCtrler.Instance.data.playerData;
        SetUpSkillQuantities();
    }
    internal void SetUpSkillQuantities()
    {
        setUpSkillQuantity(magnetQuantity, playerData.magnet.Quantity, magnetButton);
        setUpSkillQuantity(rocketQuantity, playerData.rocket.Quantity, rocketButton);
        setUpSkillQuantity(x2Quantity, playerData.x2Mutiplier.Quantity, x2Button);
    }
    public void UseMagnet() => useASkill(magnetQuantity, playerData.magnet, magnetButton);
    public void UseRocket() => useASkill(rocketQuantity, playerData.rocket, rocketButton);
    public void UseX2() => useASkill(x2Quantity, playerData.x2Mutiplier, x2Button);
    void useASkill(TMP_Text textQuantity, Skill aSkill, GameObject button)
    {
        textQuantity.text = (--aSkill.Quantity).ToString();
        if (aSkill.Quantity <= 0) button.SetActive(false);
    }
    void setUpSkillQuantity(TMP_Text textQuantity, int quantity, GameObject button)
    {
        textQuantity.text = quantity.ToString();
        if(quantity < 1)
        {
            button.SetActive(false);
        }
    }

    void pointUpdate()
    {
        point.text = statisticCounting.PlayerPoint.ToString();
    }

    internal void SwitchUIColor(bool isBlack)
    {

        foreach(var image in switchColorImages)
        {
            if (image.isBlack)
            {
                image.ChangeColor(GamePlayCtrler.Instance.switchStateWhite);
                image.isBlack = false;
            }
            else
            {
                image.ChangeColor(GamePlayCtrler.Instance.switchStateBlack);
                image.isBlack = true;
            }
        }
    }
}
