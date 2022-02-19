import { injectable } from "inversify";
import { User } from "../models/User";

export interface AuthenticationService {
    login(email: string, password: string): Promise<User>;
}

@injectable()
export default class BaseAuthenticationService implements AuthenticationService {

    private users: User[] = [{
        email: "JonahHill@mail.fi",
        firstName: "Jonah", 
        lastName: "Hill",
        id: "1"
    },
    {
        email: "JenniferLawrence@mail.fi",
        firstName: "Jennifer",
        lastName: "Lawrence",
        id: "2"
    },
    {
        email: "ChristopherEvans@mail.fi",
        firstName: "Christopher",
        lastName: "Evans",
        id: "3"
    }
    ];

    public login(email: string, password: string): Promise<User> {
        let user = this.users.find((user) => user.email == email);
        if (!user) {
            throw new Error("User not found")
        }
        return Promise.resolve<User>(user);
    }

    public getUserById(userId: string):Promise<User | null> {
        return Promise.resolve(this.users.find(_=>_.id == userId)|| null);
    }
}