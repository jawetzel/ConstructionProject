export class RegisterModel {
  Password: string;
  ConfirmPassword: string;
  Email: string;
}

export class LoginModel {
  UserName: string;
  Password: string;
}

export class TokenModel {
  SessionToken: string;
}
