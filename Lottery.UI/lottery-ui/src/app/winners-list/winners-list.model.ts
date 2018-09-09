import { UserCode, Award } from "../submit-code/submit-code.model";

export interface UserCodeAward {
    userCode: UserCode;
    award: Award;
    wonAt: Date;
}