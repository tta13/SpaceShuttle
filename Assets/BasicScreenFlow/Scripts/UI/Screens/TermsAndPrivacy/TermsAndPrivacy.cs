using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TermsAndPrivacy : MonoBehaviour
{
    [SerializeField] private TMP_Text terms;
    [SerializeField] private TMP_Text privacy;
    [SerializeField] private Button continueButton;
    [SerializeField] private Toggle acceptedTerms;
    [SerializeField] private GameObject termsPanel, privacyPanel;
    [SerializeField] private string termsScene = "TermsAndPrivacy";

    private void Start()
    {
        SetTerms();
        SetPrivacy();
        ShowTerms();
        CannotContinue();
    }

    public void SetTerms()
    {
        terms.text = "Aqui estão os \"Termos de Uso\" da <b>Plataforma Integrada de RED do MEC</b>, " +
        "isto é, as regras de funcionamento da Plataforma e seus serviços, e o que se espera de seus " +
        "usuários. Por \"usuário\", entende-se qualquer pessoa que acesse o domínio portal.mec.gov.br, " +
        "tanto para pesquisa (acesso) como para inclusão de dados e informações (participação) mediante " +
        "cadastro.\n\n Fazem parte dos Termos de Uso as políticas de responsabilidade, de privacidade e " +
        "confidencialidade, a licença de uso do conteúdo e as informações sobre como reportar violações.\n\n " +
        "Ao utilizar a <b>Plataforma Integrada de RED do MEC</b>, o usuário aceita todas as condições " +
        "aqui estabelecidas. O uso da <b>Plataforma Integrada de RED do MEC</b> implica aceite das condições " +
        "aqui elencadas.\n\n Por \"serviço\", entende-se qualquer funcionalidade ou ferramenta que permita " +
        "a interatividade com o usuáio, como, por exemplo, usuário subir um recurso, postar um comentário, " +
        "criar uma coleção ou enviar uma mensagem.\n\n A aceitação destes \"Termos de Uso\" é indispensável " +
        "à utilização da <b>Plataforma Integrada de RED do MEC</b>. Todos os usuários deverão ler, ceertificar-se " +
        "de tê-los entendido e aceitar todas as condições nele estabelecidas. Dessa forma, deve ficar claro " +
        "que a utilização desta \"<b>Plataforma Integrada de RED do MEC</b>\" implica em aceitação completa " +
        "deste documento intitulado Termos de Uso. Caso tenha dúvidas sobre os termos, utilize o formulário " +
        "disponível em \"Contato\" para saná-las.";
    }

    public void ShowTerms()
    {
        termsPanel.SetActive(true);
        privacyPanel.SetActive(false);
    }

    public void SetPrivacy()
    {
        privacy.text = "A <b>Plataforma Integrada de RED do MEC</b> tomará as medidas possíveis para manter " +
        "a confidencialidade e a segurança de suas informações. No entanto, a <b>Plataforma Integrada de RED do MEC</b> " +
        "não respoderá por prejuízos que possam ser derivados da violação dessas medidas por parte de terceiros que " +
        "subvertam os sistemas de segurança para acessar as informações de Usuários.\n\n A <b>Plataforma Integrada de RED do MEC</b> " +
        "solicitará alguns dados pessoais para seu cadastro. Além disso, dados sobre a interação dos usuários " +
        "e seu comportamento na plataforma são coletados de maneira automática. Esses dados nunca serão vendidos, " +
        "alugados, trocados ou fornecidos para fins comerciais. No entanto, o MEC poderá colaborar com instituições " +
        "públicas parceiras, como universidades, para análise desses dados bem como de qualquer conteúdo da plataforma " +
        "para fins de pesquisa, divulgação e melhoria dos serviços. Dados pessoais que possam identificá-lo nunca serão " +
        "compartilhados.\n\n Dados que não identificam o usuário serão armazenados indefinidamente para fins de pesquisa.\n\n " +
        "<b>BASICAMENTE</b>,\n\n Para manter a confidencialidade e a segurança dos dados, a Plataforma MEC RED tomará todas " +
        "as medidas possíveis.\n\n Os dados sobre interação e comportamentos dos usuários nunca serão comercializados, mas " +
        "poderão ser analisados para fins de pesquisa, divulgação e melhorias, sem a identificação dos usuários.";
    }

    public void ShowPrivacyPolicy()
    {
        termsPanel.SetActive(false);
        privacyPanel.SetActive(true);
    }

    public void OnChangeToggle()
    {
        if (acceptedTerms.isOn)
        {
            CanContinue();
        }
        else
            CannotContinue();
    }

    private void CanContinue()
    {
        continueButton.interactable = true;
    }

    private void CannotContinue()
    {
        continueButton.interactable = false;
    }

    public void Continue()
    {
        var pd = SaveSystemManager.Instance.GetPlayerData();
        pd.termsAccepted = acceptedTerms.isOn;
        SaveSystemManager.Instance.Save();

        SceneLoader.UnloadScene(termsScene);
    }
}