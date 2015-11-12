module ArabicToRoman

    type RomanDigit = I

    type RomanNumeral = RomanNumeral of RomanDigit list

    let convertToRoman arabic =
        let rec go x = 
                    match x with
                    | 1 -> [I]
                    | _ -> I :: go (x - 1)

        RomanNumeral (go arabic)