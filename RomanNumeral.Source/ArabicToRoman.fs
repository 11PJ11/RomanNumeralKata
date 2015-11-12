module ArabicToRoman

    type RomanDigit = I

    type RomanNumeral = RomanNumeral of RomanDigit list

    let convertToRoman arabic =
        match arabic with
        | 1 -> RomanNumeral [I]