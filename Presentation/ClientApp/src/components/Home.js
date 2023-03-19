import React, { useState } from 'react';
import { useQuery} from 'react-query';

const retrieveRecipes = async () => {
    const response = await fetch('/weatherforecast/GettingRecipeName');
    return await response.json();
}

export default function Home() {
    const { status, data, error } = useQuery("recipes", retrieveRecipes);

    return (
        <div>
            { JSON.stringify(data) }
        </div>
    );
}

