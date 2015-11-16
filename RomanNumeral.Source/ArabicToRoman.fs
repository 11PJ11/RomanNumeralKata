module ArabicToRoman


//to define a roman number we need some symbols
//these are:
//one five for each power of 10 so 0, 1, 2, 3
//These are used to convert from an arabic to a roman
//for example: 6 = five + one and based on the power of 10 we 
//             have different simbols so for 6 -> 10^0*(five :: one)
//                                             -> 10^0*five :: 10^0*one
//                                             -> V :: I -> VI
//  for 78 -> 10^1*(7) :: 10^0*(8)
//         -> 10^1*(five :: one :: one) :: 10^0*(five :: one :: one :: one)
//         -> (L :: X :: X) :: (V :: I :: I :: I)
//         -> LXXVIII

    type Power = Power of int
    type Digit = Digit of int 
    
    type ExpandedForm = { power : Power; digit : Digit }
    
    let expand (number:int) =
        let biggest_power = 3
        let rec go num pow (expansion:ExpandedForm list) =
           
            let powerOfTen = (int)((float)10 ** (float)pow)
            let digit = (int)(num / powerOfTen)
            let remainder = num - (digit * powerOfTen)
            let current = { power = Power(pow); digit = Digit(digit) }
            match pow with
            | 0 -> expansion @ [current]
            | _ -> if digit > 0 && digit < 10
                   then [current] @ (go (remainder) (pow - 1) (expansion))
                   else (go (remainder) (pow - 1) (expansion))
    
        go number biggest_power []




    let convertToRoman arabic =
        ""