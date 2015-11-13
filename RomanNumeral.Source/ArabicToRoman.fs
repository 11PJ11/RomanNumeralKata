module ArabicToRoman

    type RomanDigit = I | V

    type RomanNumeral = RomanNumeral of RomanDigit list

    let convertToRoman arabic =
        let rec recConversion arab = 
            match arab with
            | 1 -> [I]
            | value when value < 5 -> I :: recConversion (arab - 1)
            | _ -> [V]

        RomanNumeral (recConversion arabic)