import { ProjectDto } from './ProjectDto';
import * as React from 'react';
import { DataGrid, GridColumns } from '@mui/x-data-grid';

const columns : GridColumns = [
    { field: 'id', headerName: 'ID', minWidth: 320 },
    { field: 'name', headerName: 'Name', width: 130 },
    { 
        field: 'startTime', 
        headerName: 'Start Time', 
        type: 'date', 
        width: 160,
        valueGetter: ({ value }: any) => value && new Date(value),
    },
];

const ProjectsTable = (props: {projects: ProjectDto[]}) => (
    <div style={{ width: '100%', height: '800px' }}>
        <DataGrid
            rows={props.projects}
            columns={columns}
        />
    </div>
);

export { ProjectsTable };