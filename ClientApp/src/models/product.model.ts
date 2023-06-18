import { UserDTO } from "./UserDTO.model";

export interface Product {
    id?: string;
    title: string;
    description: string;
    price: number;
    imageUrl: string;
    category: string;
    isNew: string;
    canDeliver: string;
    city: string;
    phoneNumber: string;
    email: string;
    createdDate?: Date;
    userId?: string;
    user?: UserDTO;
  }
  
  
  