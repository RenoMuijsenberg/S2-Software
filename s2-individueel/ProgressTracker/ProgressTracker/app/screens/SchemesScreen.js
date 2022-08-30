import React, {useEffect, useState} from 'react';
import {
    Text,
    SafeAreaView,
    TouchableHighlight,
    View,
    FlatList
} from 'react-native';
import {StatusBar} from "expo-status-bar";
import AsyncStorage from "@react-native-async-storage/async-storage";
import axios from "../Axios";
import styles from "../styles/Main.styles"

function SchemesScreen({ navigation }) {
    const [workoutsArray, setWorkoutsArray] = useState([]);

    const GetAllWorkouts = navigation.addListener('focus', async () => {
        const userId = await AsyncStorage.getItem("@UserId");

        axios.get("workout/get/" + userId).then(response => {
            setWorkoutsArray(response.data.result)
        });
    });
    
    useEffect(async () => {
        await GetAllWorkouts;
    }, []);
    
    const selectWorkout = (workout) => {
        navigation.navigate("Scheme", workout)
    };
    
    const CreateNewWorkout = () => {
        navigation.navigate("Create scheme")
    }
    
    return (
        <SafeAreaView style={styles.container}>
            <StatusBar style="light"/>
            <View>
                <FlatList style={styles.listView} data={workoutsArray} renderItem={({item}) => 
                    <TouchableHighlight style={styles.buttonOutline} onPress={() => selectWorkout(item)}>
                        <Text style={styles.listText}>{item.name}</Text>
                    </TouchableHighlight>}/>
            </View>
            <View>
                <TouchableHighlight style={styles.buttonOutline} onPress={CreateNewWorkout}>
                    <Text style={styles.buttonText}>Create new workout scheme</Text>
                </TouchableHighlight>
            </View>
        </SafeAreaView>
    );
}

export default SchemesScreen;