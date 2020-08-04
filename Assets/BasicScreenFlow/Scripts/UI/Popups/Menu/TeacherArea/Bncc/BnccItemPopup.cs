using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BnccItemPopup : GenericPopup
{
    [SerializeField] private TextMeshProUGUI titleText;
    [SerializeField] private TextMeshProUGUI subtitleText;
    [SerializeField] private TextMeshProUGUI descriptionText;

    [SerializeField] private List<BnccCompetence> competences;
    [SerializeField] private List<BnccSkill> skills;

    private bool _isCompetence = false;
    private BnccCompetence _currentCompetence;
    private int _currentCompetenceIndex = 0;
    private BnccSkill _currentSkill;
    private int _currentSkillIndex = 0;

    public void SetCompetences()
    {
        titleText.text = "Competências";
        _currentCompetence = competences[_currentCompetenceIndex];
        subtitleText.text = _currentCompetence.competence;
        descriptionText.text = _currentCompetence.description;
        _isCompetence = true;
    }

    public void SetSkills()
    {
        titleText.text = "Habilidades";
        _currentSkill = skills[_currentSkillIndex];
        subtitleText.text = _currentSkill.skill;
        descriptionText.text = _currentSkill.description;
        _isCompetence = false;
    }

    public void GetNext()
    {
        if (_isCompetence)
        {
            _currentCompetenceIndex += 1;
            if (_currentCompetenceIndex >= competences.Count)
                _currentCompetenceIndex = 0;
            SetCompetences();
        }
        else
        {
            _currentSkillIndex += 1;
            if (_currentSkillIndex >= skills.Count)
                _currentSkillIndex = 0;
            SetSkills();
        }
    }

    public void GetPrevious()
    {
        if (_isCompetence)
        {
            _currentCompetenceIndex -= 1;
            if (_currentCompetenceIndex < 0)
                _currentCompetenceIndex = competences.Count - 1;
            SetCompetences();
        }
        else
        {
            _currentSkillIndex -= 1;
            if (_currentSkillIndex < 0)
                _currentSkillIndex = skills.Count - 1;
            SetSkills();
        }
    }

    public override void RequestHide()
    {
        PopupManager.Instance.ClosePopup<BnccItemPopup>();
    }
}
