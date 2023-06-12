import { Product } from "./product.model";
import { User } from "./user.model";

export interface Message {
    id: string;
    userName: string;
    content: string;
    timestamp: Date;
    userId: string;
    user: User;
  }
  