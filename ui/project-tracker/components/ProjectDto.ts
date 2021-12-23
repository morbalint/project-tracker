interface ProjectDto {
    id: string;
    name: string;
    totalDaysWorkedOn: number;
    totalHoursWorkedOn: number;
    startTime: string;
}

interface Project {
    id: string;
    name: string;
    totalDaysWorkedOn: number;
    totalHoursWorkedOn: number;
    startTime: Date;
}

export type { ProjectDto }