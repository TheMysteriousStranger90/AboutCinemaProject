export interface User {
  email: string;
  displayName: string;
  token: string;
  comments: Array<Comment>;
}
