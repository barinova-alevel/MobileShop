import { Container } from "inversify";
import ownTypes from "../ioc/ownTypes";
import LaptopService from "./services/LaptopService";
import BrandsStore from "./stores/BrandStore";
import LaptopsStore from "./stores/LaptopsStore";
import LaptopStore from "./stores/LaptopStore";
import ScreenTypesStore from "./stores/ScreenTypesStore";

export function registerLaptop(container: Container) {
    container.bind<LaptopService>(ownTypes.laptopService).to(LaptopService).inTransientScope();
    container.bind<LaptopStore>(ownTypes.laptopStore).to(LaptopStore).inTransientScope();
    container.bind<LaptopsStore>(ownTypes.laptopsStore).to(LaptopsStore).inSingletonScope();
    container.bind<BrandsStore>(ownTypes.laptopBrandsStore).to(BrandsStore).inTransientScope();
    container.bind<ScreenTypesStore>(ownTypes.laptopScreenTypesStore).to(ScreenTypesStore).inTransientScope();
}