export class RegisterModel {
  UserName: string;
  Password: string;
  ConfirmPassword: string;
  Email: string;
}

export class LoginModel {
  UserName: string;
  Password: string;
  RememberMe: boolean;
}
