import { Breeds } from './breeds.model';

export interface Groups {
    groupId: string;
    groupName: string;

    breeds?: Breeds[];
}
