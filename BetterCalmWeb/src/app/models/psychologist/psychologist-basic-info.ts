import { ProblematicBasicInfo } from '../problematic/problematic-basic-info';

export interface PsychologistBasicInfo {
    id: number;
    name: string;
    consultationMode: string;
    direction: string;
    creationDate: Date;
    problematics : ProblematicBasicInfo[];
}
