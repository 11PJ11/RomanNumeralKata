module ArabicToRoman

    let convertToRoman arabic =
        let rec recConversion arab = 
            match arab with
            | 1 -> "I"
            | value when value < 5 -> "I" + recConversion (arab - 1)
            | 5 -> "V"
            | value when value < 10 -> "V" + recConversion (arab - 5)
            | 10 -> "X"
            | value when value < 50 -> "X" + recConversion (arab - 10)

        recConversion arabic