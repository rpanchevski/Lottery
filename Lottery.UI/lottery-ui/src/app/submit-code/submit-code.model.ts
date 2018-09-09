export interface Code {
    codeValue: string;
}

export interface UserCode {
    firstName: string;
    lastName: string;
    email: string;
    code: Code;
}

export interface Award {
    awardName: string;
    awardDescription: string;
}