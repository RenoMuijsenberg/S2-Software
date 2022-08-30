import {Alert, SafeAreaView, Text, TouchableHighlight, View} from 'react-native';
import {StatusBar} from "expo-status-bar";
import Input from "../components/Input";
import {useForm} from "react-hook-form";
import AsyncStorage from "@react-native-async-storage/async-storage";
import axios from "../Axios";
import styles from "../styles/Main.styles"

function CreateSchemeScreen({ navigation }) {
    const {control, handleSubmit, formState: { errors } } = useForm();

    const CreateNewWorkout = async (data) => {
        data.UserId = await AsyncStorage.getItem("@UserId");
        
        await axios.post("workout/create", JSON.stringify(data)).then(response =>{
            Alert.alert("Success", response.data.userMessage)
        });
    }

    return (
        <SafeAreaView style={styles.container}>
            <StatusBar style="light"/>
            <View>
                <Input label={"Name"} name="Name" required={true} control={control}/>
                {errors.Name && <Text style={styles.error}>{errors.Name.message}</Text>}
                <Input label={"Note"} name="Note" required={false} control={control}/>
                {errors.Note && <Text style={styles.error}>{errors.Note.message}</Text>}
            </View>
            <View>
                <TouchableHighlight style={styles.buttonOutline} onPress={handleSubmit(CreateNewWorkout)}>
                    <Text style={styles.buttonText}>Create new workout scheme</Text>
                </TouchableHighlight>
            </View>
        </SafeAreaView>
    );
}

export default CreateSchemeScreen;