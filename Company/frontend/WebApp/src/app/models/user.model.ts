import { Login } from './login.model';

export class User {
  id?: number;
  email: string;
  fullName: string;
  role?: string;
  token?: string;
  login: Login;
}
