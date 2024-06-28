namespace Five.Bank.Domain.Specifications.v1;

public class DocumentAlgorithmSpecification(string document)
{
    public bool IsSatisfied()
    {
        if (string.IsNullOrWhiteSpace(document))
            return false;

        var clearDocument = document.Trim();
        clearDocument = clearDocument.Replace("-", "");
        clearDocument = clearDocument.Replace(".", "");

        if (clearDocument.Length != 11)
            return false;

        var totalDigitI = 0;
        var totalDigitIi = 0;

        if (clearDocument.Equals("00000000000") ||
            clearDocument.Equals("11111111111") ||
            clearDocument.Equals("22222222222") ||
            clearDocument.Equals("33333333333") ||
            clearDocument.Equals("44444444444") ||
            clearDocument.Equals("55555555555") ||
            clearDocument.Equals("66666666666") ||
            clearDocument.Equals("77777777777") ||
            clearDocument.Equals("88888888888") ||
            clearDocument.Equals("99999999999"))
            return false;

        if (clearDocument.Any(c => !char.IsNumber(c)))
            return false;

        var documentArray = new int[11];

        for (var i = 0; i < clearDocument.Length; i++) documentArray[i] = int.Parse(clearDocument[i].ToString());

        for (var i = 0; i < documentArray.Length - 2; i++)
        {
            totalDigitI += documentArray[i] * (10 - i);
            totalDigitIi += documentArray[i] * (11 - i);
        }

        var modI = totalDigitI % 11;
        if (modI < 2)
            modI = 0;
        else
            modI = 11 - modI;

        if (documentArray[9] != modI) return false;

        totalDigitIi += modI * 2;

        var modIi = totalDigitIi % 11;
        if (modIi < 2)
            modIi = 0;
        else
            modIi = 11 - modIi;
        return documentArray[10] == modIi;
    }
}